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
    }
}
