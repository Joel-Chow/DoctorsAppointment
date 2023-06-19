using System;
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

        public async Task Create(
            string doctorName,
            bool isReserved,
            decimal cost
            )
        {
            // check if the name is not empty
            if (string.IsNullOrEmpty(doctorName))
            {
                throw new DoctorNameEmptyException();
            }

            // make sure the slot is not available 
            var exists = _doctorAvailabilityRepo.SlotExist(isReserved);
            if (exists)
            {
                throw new SlotAlreadyExistsException(isReserved);
            }

            // create new availability
            var doctorAvailability = new DoctorAvailability 
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                DoctorId = Guid.NewGuid(),
                DoctorName = doctorName, 
                IsReserved = isReserved,
                Cost = cost
            };

            // add doctor availability with parameters
            await _doctorAvailabilityRepo.Add(doctorAvailability);
        }
    }
}