using System;
using DoctorsAppointment.Entities;

namespace DoctorsAppointment.Repositories
{
    public interface IDoctorsAvailabilityRepo
    {
        public bool SlotExist(DateTime date);
        public Task Add(DoctorAvailability slot);
    }
}