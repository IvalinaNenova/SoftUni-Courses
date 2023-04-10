using Trucks.Data.Models;

namespace Trucks.Data
{
    using Microsoft.EntityFrameworkCore;

    public class TrucksContext : DbContext
    {
        public TrucksContext()
        { 
        }

        public TrucksContext(DbContextOptions options)
            : base(options) 
        { 
        }

        public DbSet<Truck> Trucks { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Despatcher> Despatchers { get; set; } = null!;
        public DbSet<ClientTruck> ClientsTrucks { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientTruck>(e =>
            {
                e.HasKey(ct => new
                {
                    ct.ClientId,
                    ct.TruckId
                });
            });
        }
    }
}
