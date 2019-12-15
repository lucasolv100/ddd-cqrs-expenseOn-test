using Hotel.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class HotelContext : DbContext
    {

        public DbSet<Domain.Entites.Hotel> AnuncioWebmotors { get; set; }
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}