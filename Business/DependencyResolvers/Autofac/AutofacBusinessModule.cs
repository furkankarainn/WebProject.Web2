using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.Hangfire;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));
            configurationManager.AddJsonFile("appsettings.json");

            builder.RegisterType<EfMenuDal>().As<IMenuDal>().SingleInstance();
            builder.RegisterType<MenuManager>().As<IMenuService>().SingleInstance();// data tutmadığı için tek bir instance oluşturup herkese onu versin.

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            builder.RegisterType<Hangfire.Hangfire>().As<IHangfire>().SingleInstance();
            builder.RegisterAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());
            builder.Register(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<WebProjectDbContext>();
                optionsBuilder.UseSqlServer(configurationManager.GetConnectionString("WebProjectConnection"));

                return new WebProjectDbContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();




            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                return new BackgroundJobClient(new SqlServerStorage(configurationManager.GetConnectionString("WebProjectConnection")));
            }).As<IBackgroundJobClient>().SingleInstance();

            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                return new RecurringJobManager(new SqlServerStorage(configurationManager.GetConnectionString("WebProjectConnection")));
            }).As<IRecurringJobManager>().SingleInstance();




            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector=new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
