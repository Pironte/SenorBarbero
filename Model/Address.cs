using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SenorBarbero.Model
{
    [Table("Endereco")]
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        [Column("Rua")]
        public string? Street { get; set; }

        [Required, MaxLength(20)]
        [Column("Numero")]
        public string? Number { get; set; }

        [MaxLength(100)]
        [Column("Complemento")]
        public string? Complement { get; set; }

        [Required, MaxLength(100)]
        [Column("Bairro")]
        public string? Neighborhood { get; set; }

        [Required, MaxLength(100)]
        [Column("Cidade")]
        public string? City { get; set; }

        [Required, MaxLength(100)]
        [Column("Estado")]
        public string? State { get; set; }

        [Required, MaxLength(20)]
        [Column("CEP")]
        public string? PostalCode { get; set; }

        [Required, MaxLength(100)]
        [Column("Pais")]
        public string? Country { get; set; }

        public virtual User? User { get; set; }
    }
}