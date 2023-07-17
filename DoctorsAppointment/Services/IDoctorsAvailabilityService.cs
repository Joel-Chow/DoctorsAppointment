using System;
using DoctorsAppointment.Entities;

namespace DoctorsAppointment.Services
{
    public interface IDoctorsAvailabilityService
    {
        public Task Create(Slot slot);

        public Task<IEnumerable<object>> CheckAppointment(string? doctorName);
    }
}