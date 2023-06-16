using DoctorsAppointment.Entities;

namespace DoctorsAppointment.Repositories
{
    public class IDoctorsAvailabilityRepository
    {
        public bool DoctorsAvailabilityExists(string name);
        public Task Add(DoctorsAvailability doctorsAvailability);
    }
}
