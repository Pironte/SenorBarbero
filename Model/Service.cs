using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenorBarbero.Model
{
    [Table("Servico")]
    public class Service
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column("Descricao")]
        public string? Description { get; set; }

        [Required]
        [Column("Preco")]
        public decimal Price { get; set; }
    }
}
