using DoctorsAppointment.Entities;
using DoctorsAppointment.Repositories;

namespace DoctorsAppointment.Services
{
    public class DoctorsAvailabilityService : IDoctorsAvailabilityService
    {
        private readonly IDoctorsAvailabilityRepository _doctorRepository;
        public DoctorsAvailabilityService(IDoctorsAvailabilityRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task Create(DoctorsAvailability doctorsAvailability)
        {
            // check doctor name is unique
            if (string.IsNullOrEmpty(doctorsAvailability.DoctorName))
            {
                throw new DoctorNameException();
            }


            // check doctor name is not empty
            var exists = _doctorRepository.DoctorsAvailabilityExists(doctorsAvailability.DoctorName)
            if(exists)
            {
                throw new DoctorNameExistsException(doctorsAvailability.DoctorName);
            }

            await _doctorRepository.Add(doctorsAvailability);
        }
    }
}
