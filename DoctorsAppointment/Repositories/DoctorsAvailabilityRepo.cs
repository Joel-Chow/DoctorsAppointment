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
        async Task IDoctorsAvailabilityRepo.Add(Slot slot)
        {
            _database.Add(slot);
            await _database.SaveChangesAsync();
        }

        public async Task<IEnumerable<object>> Check(string doctorId)
        {
            // returns list of free appointments
            var freeSlots = await _database.DoctorAvailabilities.Where(x => x.DoctorId == doctorId).ToListAsync();
            List<string> freeDoctor = new List<string>();

            foreach (var freeSlot in freeSlots)
            {
                var message = "\t" + freeSlot.Date.ToString();
                if (freeSlot.IsReserved == false)
                {
                    freeDoctor.Add(message);
                }
            }

            return freeDoctor;
        }
    }
}
