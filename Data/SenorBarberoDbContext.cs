using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SenorBarbero.Model;

namespace SenorBarbero.Data
{
    public class SenorBarberoDbContext : IdentityDbContext<User>
    {
        public SenorBarberoDbContext(DbContextOptions<SenorBarberoDbContext> opts) : base(opts)
        {
        }

        public override DbSet<User> Users { get; set; }

        public DbSet<Configurations> Configurations { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<BarberShop> Bars { get; set; }

        public DbSet<SocialMedia> SocialMedia { get; set; }
    }
}
