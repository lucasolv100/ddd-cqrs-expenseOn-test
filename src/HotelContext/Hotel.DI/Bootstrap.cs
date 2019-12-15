using System;
using Hotel.Data;
using Hotel.Data.Repositories;
using Hotel.Data.UnitOfWork;
using Hotel.Domain.Interfaces;
using Hotel.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.DI
{
    public class Bootstrap
    {
        public static void Configure(
            IServiceCollection services,
            string connectionString
        )
        {
            services.AddDbContext<HotelContext>(options => options.UseSqlServer(connectionString));
            
            //Configuração de interfaces
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IHotelRepository), typeof(HotelRepository));
            services.AddScoped(typeof(IRepository<Domain.Entites.Hotel>), typeof(HotelRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
