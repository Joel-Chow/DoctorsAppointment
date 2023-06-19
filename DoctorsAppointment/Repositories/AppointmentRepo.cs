using DoctorsAppointment.Database;
using DoctorsAppointment.Entities;

namespace DoctorsAppointment.Repositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private DoctorAppointmentDatabase _database;

        public AppointmentRepo(DoctorAppointmentDatabase database)
        {
            _database = database;
        }
        public async Task Add(Appointment appointment)
        {
            _database.Add(appointment);
            await _database.SaveChangesAsync();
        }
    }
}
