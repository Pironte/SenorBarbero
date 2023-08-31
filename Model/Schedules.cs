using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenorBarbero.Model
{
    public class Schedules
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public TimeSpan Schedule { get; set; }

        [ForeignKey("BarberShop")]
        [Column("Barbearia_Id")]
        public int BarberShopId { get; set; }

        public virtual BarberShop? BarberShop { get; set; }
    }
}
