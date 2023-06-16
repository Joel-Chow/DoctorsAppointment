namespace DoctorsAppointment.Services
{
    public class Doctors: IDoctors
    {
        private readonly IDoctors _doctorsRepository;
        public Doctors(IDoctors doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }
        public async Task Create(string doctorsAvailability)
        {
            // check if the entered empty availability input
            if (string.IsNullOrEmpty(doctorsAvailability))
            {
                // throw new exception
                throw new UndeclaredDoctorAvailability();
            }

            // make sure there's no duplicated availability
            var exists = _doctorsRepository.AvailabilityExist(doctorsAvailability);
            if (exists)
            {
                throw new CategoryAlreadyExistsException(doctorsAvailability);
            }
            var availability = new Availability { Name = doctorsAvailability, Id = Guid.NewGuid() };

            await _doctorsRepository.Add(availability);
        }
    }
    }
}
