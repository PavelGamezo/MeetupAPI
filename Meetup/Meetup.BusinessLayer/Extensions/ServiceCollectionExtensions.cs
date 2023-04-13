using Meetup.BusinessLayer.Interfaces;
using Meetup.BusinessLayer.Services.Authentication;
using Meetup.BusinessLayer.Services.Meetings;
using Meetup.BusinessLayer.Services.User;
using Meetup.DataAccessLayer.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BusinessLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IMeetingService, MeetingService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(Assembly.GetCallingAssembly(),
                                   Assembly.GetExecutingAssembly());

            services.AddDataAccessLayer(configuration, connectionString);

            return services;
        }
    }
}
