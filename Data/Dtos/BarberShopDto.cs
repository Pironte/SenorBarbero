using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SenorBarbero.Data.Dtos
{
    public class BarberShopDto
    {
        [Required]
        [Column("Nome")]
        public string? Name { get; set; }

        [Column("Descricao")]
        public string? Description { get; set; }
    }
}
