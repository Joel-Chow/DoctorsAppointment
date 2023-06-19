using System;
using DoctorsAppointment.Entities;

namespace DoctorsAppointment.Services
{
    public interface IDoctorsAvailabilityService
    {
        public Task Create(DoctorAvailability slot);
    }
}