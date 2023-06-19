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

        public async Task Create(DoctorAvailability slot)
        {
            // check if the name is not empty
            if (string.IsNullOrEmpty(slot.DoctorName))
            {
                throw new DoctorNameEmptyException();
            }

            // make sure the slot is not available 
            var exists = _doctorAvailabilityRepo.SlotExist(slot.Date);
            if (exists)
            {
                throw new SlotAlreadyExistsException(slot.Date);
            }
            await _doctorAvailabilityRepo.Add(slot);
        }
    }
}