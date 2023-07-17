using DoctorsAppointment.Entities;
using DoctorsAppointment.Services;

namespace DoctorsAppointment.Repositories
{
    public interface IAppointmentRepo
    {
        public Task Add(PaitentBooking appointment);

        public Task<List<string>> Check(PaitentBooking appointment);
    }
}
