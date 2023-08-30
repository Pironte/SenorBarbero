using Microsoft.EntityFrameworkCore;
using SenorBarbero.Model;

namespace SenorBarbero.Data
{
    public class SenorBarberoDbContext : DbContext
    {
        public SenorBarberoDbContext(DbContextOptions<SenorBarberoDbContext> opts) : base(opts)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<BarberShop> Bars { get; set; }

        public DbSet<SocialMedia> SocialMedia { get; set; }
    }
}
