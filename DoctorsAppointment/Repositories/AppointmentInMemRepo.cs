using DoctorsAppointment.Entities;
using DoctorsAppointment.Services;

namespace DoctorsAppointment.Repositories
{
    public class AppointmentInMemRepo: IAppointmentRepo
    {
        private static readonly List<Appointment> Appointments = new();

        public async Task Add(Appointment appointment)
        {
            Appointments.Add(appointment);

        }
    }
}
