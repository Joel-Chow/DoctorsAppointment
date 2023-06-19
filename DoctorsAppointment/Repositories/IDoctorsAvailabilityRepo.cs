using System;
using DoctorsAppointment.Entities;
using Microsoft.Extensions.Hosting;

namespace DoctorsAppointment.Repositories
{
    public interface IDoctorsAvailabilityRepo
    {
        public bool SlotExist(bool isReserved);
        public Task Add(DoctorAvailability doctorAvailability);
    }
}