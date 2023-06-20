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

        public async Task Create(DoctorAvailability availability)

        {
            // check if doctorName input is not null
            if (availability.DoctorName == "")
            {
                throw new DoctorNameEmptyException();
            }

            // change datetime configurations
            availability.Date = Convert.ToDateTime(availability.Date);

            // create new Guid
            availability.DoctorId = Guid.NewGuid();

            if (availability.Cost < 0)
            {
                throw new NegativeCostException();
            }

            // add doctor availability with parameters
            await _doctorAvailabilityRepo.Add(availability);
        }

        public async Task<IEnumerable<object>> CheckAppointment(string? doctorName)
        {
            // gets list of free appointments
            return await _doctorAvailabilityRepo.Check(doctorName);
        }
    }
}