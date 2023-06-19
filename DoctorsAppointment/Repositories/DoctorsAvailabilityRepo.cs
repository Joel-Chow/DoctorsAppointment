using DoctorsAppointment.Database;
using DoctorsAppointment.Entities;

namespace DoctorsAppointment.Repositories
{
    public class DoctorsAvailabilityRepo : IDoctorsAvailabilityRepo
    {
        private DoctorAppointmentDatabase _database;
        public DoctorsAvailabilityRepo(DoctorAppointmentDatabase database)
        {
            _database = database;
        }
        async Task IDoctorsAvailabilityRepo.Add(DoctorAvailability doctorAvailability)
        {
            _database.Add(doctorAvailability);
            await _database.SaveChangesAsync();
        }
    }
}
