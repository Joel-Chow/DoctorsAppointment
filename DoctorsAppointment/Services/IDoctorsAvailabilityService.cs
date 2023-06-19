using System;
using DoctorsAppointment.Entities;

namespace DoctorsAppointment.Services
{
    public interface IDoctorsAvailabilityService
    {
        public Task Create(
            string doctorName,
            /* Guid doctorId, */
            string slotTime,
            bool isReserved,
            decimal cost
            );
    }
}