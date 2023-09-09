using System.ComponentModel.DataAnnotations;

namespace SenorBarbero.Data.Dtos
{
    public class ScheduleDto
    {
        [Required]
        public int ScheduleSlotId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public string? UserId { get; set; }

        [Required]
        public int BarberShopId { get; set; }
    }
}
