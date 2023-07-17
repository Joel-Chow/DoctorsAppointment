using System.ComponentModel.DataAnnotations;

namespace DoctorsAppointment.Entities
{
    public class PaitentBooking
    {
        public Guid Id { get; set; }
        public Guid SlotId { get; set; }
        public Guid PaitentId { get; set; }
        public string PaitentName { get; set; }
        public string Date { get; set; }
    }
}

