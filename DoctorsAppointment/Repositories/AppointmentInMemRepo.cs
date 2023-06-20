/*using DoctorsAppointment.Entities;
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

        public async Task Check(Appointment appointment)
        {
            await _database.DoctorAvailabilities.Where(x => x.IsReserved == true).ToListAsync();
        }
    }
}
*/