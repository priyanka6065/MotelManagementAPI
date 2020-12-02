using MotelManagementAPI.Application.Interfaces;
using MotelManagementAPI.Application.Interfaces.Repositories;
using MotelManagementAPI.Infrastructure.Persistence.Contexts;
using MotelManagementAPI.Infrastructure.Persistence.Repositories;
using MotelManagementAPI.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotelManagementAPI.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly("MotelManagementAPI.WebApi")));
                //b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
            services.AddTransient<IRoomDetailsRepositoryAsync, RoomDetailsRepositoryAsync>();
            services.AddTransient<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
            #endregion
        }
    }
}
