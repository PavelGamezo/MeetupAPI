using Meetup.BusinessLayer.Interfaces;
using Meetup.BusinessLayer.Services.Events;
using Meetup.Data.Extensions;
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
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IMeetingService, MeetingService>();
            services.AddDatabase(connectionString);
            services.AddAutoMapper(Assembly.GetCallingAssembly(),
                                   Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
