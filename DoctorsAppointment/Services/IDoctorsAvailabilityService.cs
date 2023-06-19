using System;
using DoctorsAppointment.Entities;

namespace DoctorsAppointment.Services
{
    public interface IDoctorsAvailabilityService
    {
        public Task Create(
            string doctorName,
            string date,
            bool isReserved,
            decimal cost
            );
    }
}