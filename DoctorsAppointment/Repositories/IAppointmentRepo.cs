using DoctorsAppointment.Entities;
using DoctorsAppointment.Services;

namespace DoctorsAppointment.Repositories
{
    public interface IAppointmentRepo
    {
        public Task Add(Appointment appointment);
    }
}
