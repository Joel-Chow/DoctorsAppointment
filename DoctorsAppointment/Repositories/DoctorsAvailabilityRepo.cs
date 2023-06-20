using DoctorsAppointment.Database;
using DoctorsAppointment.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<object>> Check(string? doctorName)
        {
            // returns list of free appointments
            var freeSlots = await _database.DoctorAvailabilities.Where(x => x.DoctorName == doctorName).ToListAsync();
            List<string> freeDoctor = new List<string>();

            foreach (var freeSlot in freeSlots)
            {
                var message = "Slot " + freeSlot.Date.ToString();
                if (freeSlot.IsReserved == true)
                {
                    message = message + " is reserved.";
                }
                else
                {
                    message = message + " is not reserved.";
                }

                freeDoctor.Add(message);
            }

            return freeDoctor;
        }
    }
}
