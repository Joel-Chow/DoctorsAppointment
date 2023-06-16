using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoctorsAppointment.Entities
{
    public class DoctorsAvailability
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
    }
}
