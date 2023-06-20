using DoctorsAppointment.Entities;

namespace DoctorsAppointment.Services
{
    public interface IPaitentAppointmentService
    {
        public Task CreateAppointment(Appointment appointment);
        public Task<List<string>> CheckAppointment(Appointment appointment);
    }

}
