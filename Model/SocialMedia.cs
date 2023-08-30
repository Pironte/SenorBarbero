using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SenorBarbero.Enums.GlobalEnums;

namespace SenorBarbero.Model
{
    [Table("RedeSocial")]
    public class SocialMedia
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column("Rede")]
        public SocialNetwork socialNetwork { get; set; }

        [ForeignKey("BarberShop")]
        [Column("Barbearia_Id")]
        public int BarberShopId { get; set; }

        public virtual BarberShop? BarberShop { get; set; }
    }
}
