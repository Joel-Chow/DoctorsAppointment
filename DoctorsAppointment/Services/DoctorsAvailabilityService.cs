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
    }
}