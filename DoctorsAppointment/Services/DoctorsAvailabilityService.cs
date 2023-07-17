using System;
using DoctorsAppointment.Services.Exceptions;
using DoctorsAppointment.Services;
using DoctorsAppointment.Entities;
using DoctorsAppointment.Repositories;

namespace DoctorsAppointment.Services
{
    public class DoctorsAvailabilityService : IDoctorsAvailabilityService
    {
        private readonly IDoctorsAvailabilityRepo _doctorAvailabilityRepo;
        public DoctorsAvailabilityService(IDoctorsAvailabilityRepo doctorAvailabilityRepo)
        {
            _doctorAvailabilityRepo = doctorAvailabilityRepo;
        }

        public async Task Create(Slot slot)

        {
            // check if doctorName input is not null
            if (slot.DoctorName == "")
            {
                throw new DoctorNameEmptyException();
            }

            // change datetime configurations
            slot.Date = Convert.ToDateTime(slot.Date);

            // create new Guid
            slot.DoctorId = Guid.NewGuid();

            if (slot.Cost < 0)
            {
                throw new NegativeCostException();
            }

            // add doctor availability with parameters
            await _doctorAvailabilityRepo.Add(slot);
        }

        public async Task<IEnumerable<object>> CheckAppointment(string? doctorName)
        {
            // gets list of free appointments
            return await _doctorAvailabilityRepo.Check(doctorName);
        }
    }
}