using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorsAppointment.Entities
{
    public class Slot
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        
        public string? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        [Required]
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
    }
}