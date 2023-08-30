using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SenorBarbero.Enums.GlobalEnums;

namespace SenorBarbero.Model
{
    [Table("Usuario")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        public string? Name { get; set; }

        [Required]
        [Column("Email")]
        public string? Email { get; set; }

        [Required]
        [Column("Senha")]
        public string? Password { get; set; }

        [NotMapped]
        public string? EmailConfirmed { get; set; }

        [Required]
        [Column("Perfil")]
        public Profile Profile { get; set; }

        [ForeignKey("Address")]
        [Column("Endereco_Id")]
        public int AddressId { get; set; }
        public virtual Address? Address { get; set; }

        [ForeignKey("Configuration")]
        [Column("Configuracao_Id")]
        public int ConfigurationId { get; set; }
        public virtual Configuration? Configuration { get; set; }
    }
}
