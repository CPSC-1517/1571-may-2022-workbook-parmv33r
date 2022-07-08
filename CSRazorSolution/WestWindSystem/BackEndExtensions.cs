using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.BLL;
using WestWindSystem.DAL;

namespace WestWindSystem
{
    public static class BackEndExtensions
    {
        public static void WWBackEndDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            // we will register all the services that will
            //  be used by the system (context setup)
            //  and will be provided by the system (BLL Services)

            //register the context service
            //options contents the connection string information
            services.AddDbContext<WestWindContext>(options);

            //register EACH service class (BLL Classes)
            // reach service class will have an AddTransient<T>() method

            //use the AddTransient<T>() method where T is your BLL Class name
            //AddTrainsient is called a factory

            services.AddTransient<BuildVersionServices>((serviceProvider) =>
            {
                // get the context class that was registered above in AddDbContext
                var context = serviceProvider.GetService<WestWindContext>();

                //create an instance of the service class (BuildVersionServices)
                //      supplying the context reference to the service class
                return new BuildVersionServices(context);
            });
        }

    }
}

