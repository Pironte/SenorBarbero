using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SenorBarbero.Model.Configuration
{
    public class BarberShopConfiguration : IEntityTypeConfiguration<BarberShop>
    {
        public void Configure(EntityTypeBuilder<BarberShop> builder)
        {
            builder.Property(a => a.Description)
               .HasComment("Descricão da barbearia");

            builder.Property(a => a.Name)
                   .HasComment("Nome da barberaria");

            builder.Property(a => a.Schedules)
                   .HasComment("Horários disponíveis na barbearia");
        }
    }
}
