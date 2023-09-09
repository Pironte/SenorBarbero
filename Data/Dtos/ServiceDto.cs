using System.ComponentModel.DataAnnotations;

namespace SenorBarbero.Data.Dtos
{
    public class ServiceDto
    {
        [Required]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
