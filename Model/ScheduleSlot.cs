using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenorBarbero.Model
{
    [Table("Horarios")]
    public class ScheduleSlot
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column("Horario")]
        public TimeSpan Schedule { get; set; }
    }
}
