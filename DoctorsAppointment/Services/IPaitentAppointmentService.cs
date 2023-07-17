using DoctorsAppointment.Entities;

namespace DoctorsAppointment.Services
{
    public interface IPaitentAppointmentService
    {
        public Task CreateAppointment(PaitentBooking appointment);
        public Task<List<string>> CheckAppointment(PaitentBooking appointment);
    }

}
