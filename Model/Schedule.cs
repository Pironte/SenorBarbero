using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenorBarbero.Model
{
    [Table("Agenda")]
    public class Schedule
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Schedules")]
        [Column("Horarios_Id")]
        public int ScheduleSlotId { get; set; }
        public virtual ScheduleSlot? ScheduleSlot { get; set; }

        [Required]
        [ForeignKey("Service")]
        [Column("Servico_Id")]
        public int ServiceId { get; set; }
        public virtual Service? Service { get; set; }

        [Required]
        [ForeignKey("User")]
        [Column("Usuario_Id")]
        public string? UserId { get; set; }
        public virtual User? User { get; set; }

        [Required]
        [ForeignKey("BarberShop")]
        [Column("Barbearia_Id")]
        public int BarberShopId { get; set; }
        public virtual Service? BarberShop { get; set; }
    }
}
