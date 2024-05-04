using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));
            configurationManager.AddJsonFile("appsettings.json");

            services.AddScoped<IMenuService, MenuManager>();
            services.AddScoped<IMenuDal, EfMenuDal>();

            services.AddDbContext<WebProjectDbContext>(options =>
            {
                options.UseSqlServer(configurationManager.GetConnectionString("WebProjectConnection"));
            });
            return services;
        }
    }
}
