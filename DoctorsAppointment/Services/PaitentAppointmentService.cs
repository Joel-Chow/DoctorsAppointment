using DoctorsAppointment.Entities;
using DoctorsAppointment.Repositories;

namespace DoctorsAppointment.Services
{
    public class PaitentAppointmentService : IPaitentAppointmentService
    {
        private readonly IAppointmentRepo _appointmentRepo;
        private readonly ILogger<PaitentAppointmentService> _logger;
        public PaitentAppointmentService(IAppointmentRepo appointmentRepo, ILogger<PaitentAppointmentService> logger)
        {
            _appointmentRepo = appointmentRepo;
            _logger = logger;
        }

        public async Task CreateAppointment(PaitentBooking appointment, string doctorId)
        {
            // add ids
            appointment.SlotId = Guid.NewGuid();
            appointment.PaitentId = Guid.NewGuid();

            await _appointmentRepo.Add(appointment);
            _logger.LogInformation(
                "Appointment has been made with the following details:\n" +
                $"\tPaitent Name: {appointment.PaitentName}\n" +
                $"\tAppointment Time: {appointment.Date}\n" +
                $"\tDoctor ID: {doctorId}\n");
        }

        public async Task<List<string>> CheckAppointment(string requestId)
        {
            // gets list of free appointments
            // remove strings ahead
            var doctorId = requestId.Replace("/appointments/", "");
            _logger.LogInformation("Checking for Doctor's Appointments ");
            return await _appointmentRepo.Check(doctorId);
        }
    }
}
