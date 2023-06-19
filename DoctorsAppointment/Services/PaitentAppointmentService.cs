using DoctorsAppointment.Entities;
using DoctorsAppointment.Repositories;

namespace DoctorsAppointment.Services
{
    public class PaitentAppointmentService : IPaitentAppointmentService
    {
        private readonly IAppointmentRepo _appointmentRepo;
        public PaitentAppointmentService(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            // check if datetime is free

            await _appointmentRepo.Add(appointment);
        }
    }
}
