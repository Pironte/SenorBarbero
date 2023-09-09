using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenorBarbero.Model
{
    public class User : IdentityUser
    {
        [ForeignKey("Configuration")]
        [Column("Configuracao_Id")]
        public int? ConfigurationId { get; set; }
        public virtual Configuration? Configuration { get; set; }
    }
}
