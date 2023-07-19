using DoctorsAppointment.Entities;

namespace DoctorsAppointment.Services
{
    public interface IPaitentAppointmentService
    {
        public Task CreateAppointment(PaitentBooking appointment, string doctorIds);
        public Task<List<string>> CheckAppointment(string doctorId);
    }

}
