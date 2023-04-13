using Meetup.DataAccessLayer.Authentication.Interfaces;
using Meetup.DataAccessLayer.Authentication;
using Meetup.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Meetup.DataAccessLayer.Repositories.Interfaces;
using Meetup.DataAccessLayer.UnitOfWork.Interfaces;
using Meetup.DataAccessLayer.Repositories;
using Meetup.DataAccessLayer.UnitOfWork;

namespace Meetup.DataAccessLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services,
            IConfiguration configuration,
            string connectionString)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IMeetingRepository, MeetingRepository>();
            services.AddScoped<IUnitOfWork, ApplicationUnitOfWork>();

            services.AddDbContext<MeetupDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Meetup.DataAccessLayer"));
            });

            services.AddIdentityServices();
            services.AddAuth(configuration);

            return services;
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<MeetupDbContext>()
                    .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            var JwtSettings = new JwtSettings();
            configuration.Bind("JWTSettings", JwtSettings);

            services.AddSingleton(Options.Create(JwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer
            .AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = JwtSettings.ValidAudience,
                    ValidIssuer = JwtSettings.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret))
                };
            });

            return services;
        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(q =>
            {
                q.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Assembly.GetExecutingAssembly().GetName().Name} v1");
            });
        }
    }
}
