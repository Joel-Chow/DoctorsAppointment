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
        private readonly ILogger<DoctorsAvailabilityService> _logger;
        public DoctorsAvailabilityService(IDoctorsAvailabilityRepo doctorAvailabilityRepo, ILogger<DoctorsAvailabilityService> logger)
        {
            _doctorAvailabilityRepo = doctorAvailabilityRepo;
            _logger = logger;
        }

        public async Task Create(Slot slot, string doctorId)

        {
            // check if doctorName input is not null
            if (slot.DoctorName == "")
            {
                _logger.LogError("Doctor has no name");
                throw new DoctorNameEmptyException();
            }

            // change datetime configurations
            slot.Date = Convert.ToDateTime(slot.Date);

            // create new Guid
            slot.DoctorId = doctorId;

            if (slot.Cost < 0)
            {
                _logger.LogError("Input cost is negative");
                throw new NegativeCostException();
            }

            // add doctor availability with parameters
            await _doctorAvailabilityRepo.Add(slot);
        }

        public async Task<IEnumerable<object>> CheckAppointment(string requestId)
        {

            // remove strings ahead
            var doctorId = requestId.Replace("/slots/", "");

            // gets list of free appointments

            // throw exception is doctorId does not exist

            return await _doctorAvailabilityRepo.Check(doctorId);
        }
    }
}