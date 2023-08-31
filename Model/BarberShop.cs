using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenorBarbero.Model
{
    [Table("Barbearia")]
    public class BarberShop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        public string? Name { get; set; }

        [Column("Descricao")]
        public string? Description { get; set; }

        public virtual ICollection<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();

        public virtual ICollection<Schedules> Schedules { get; set; } = new List<Schedules>();
    }
}
