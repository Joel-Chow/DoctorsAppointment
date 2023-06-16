namespace DoctorsAppointment.Repositories
{
    public interface IDoctorsAvailabilityRepository
    {
        public bool DoctorsAvailabilityExist(string name);
    }
}