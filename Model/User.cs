using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SenorBarbero.Enums.GlobalEnums;

namespace SenorBarbero.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string EmailConfirmed { get; set; }

        [Required]
        public Profile Profile { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Configuration")]
        public int ConfigurationId { get; set; }
        public Configuration Configuration { get; set; }
    }
}
