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
        public async Task Add(Appointment appointment)
        {
            _database.Add(appointment);
            await _database.SaveChangesAsync();
        }

        public async Task<List<string>> Check(Appointment appointment)
        {
            // returns list of free appointments
            var freeSlots = await _database.DoctorAvailabilities.Where(x => x.IsReserved == true).ToListAsync();
            List<string> freeDoctor = new List<string>();
            
            foreach(var freeSlot in freeSlots)
            {
                var message = "Doctor " + freeSlot.DoctorName.ToString() + " is free at time slot: " + freeSlot.Date.ToString();
                freeDoctor.Add(message);
            }

            return freeDoctor;
        }

    }
}
