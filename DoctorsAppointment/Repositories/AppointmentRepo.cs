using DoctorsAppointment.Database;
using DoctorsAppointment.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace DoctorsAppointment.Repositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private DoctorAppointmentDatabase _database;

        public AppointmentRepo(DoctorAppointmentDatabase database)
        {
            _database = database;
        }
        public async Task Add(PaitentBooking appointment)
        {
            _database.Add(appointment);
            await _database.SaveChangesAsync();
        }

        public async Task<List<string>> Check(string doctorId)
        {
            // returns list of free appointments
            var doctor = await _database.DoctorAvailabilities.Where(x => x.DoctorId == doctorId).ToListAsync();
            List<string> freeDoctor = new List<string>();
            
            foreach(var freeSlot in doctor)
            {
                if (freeSlot.IsReserved == false)
                {
                    freeDoctor.Add(freeSlot.Date.ToString());
                }
            }

            return freeDoctor;
        }

    }
}
