using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenorBarbero.Model
{
    [Table("Configuracao")]
    public class Configuration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Linguagem")]
        public string? Language { get; set; }

        [Column("HabilitaNotificacao")]
        public bool EnableNotification { get; set; }

        public virtual User? User { get; set; }
    }
}