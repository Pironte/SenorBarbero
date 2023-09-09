using System.ComponentModel.DataAnnotations;

namespace SenorBarbero.Data.Dtos
{
    public class ScheduleSlotDto
    {
        [Required]
        public TimeSpan Schedule { get; set; }
    }
}
