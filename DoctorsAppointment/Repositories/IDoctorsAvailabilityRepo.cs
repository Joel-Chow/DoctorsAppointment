using System;
using DoctorsAppointment.Entities;
using Microsoft.Extensions.Hosting;

namespace DoctorsAppointment.Repositories
{
    public interface IDoctorsAvailabilityRepo
    {
        public Task Add(Slot slot);

        Task<IEnumerable<object>> Check(string? doctorName);
    }
}