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

        public async Task CreateAppointment(PaitentBooking appointment)
        {
            // add ids
            appointment.SlotId = Guid.NewGuid();
            appointment.PaitentId = Guid.NewGuid();

            await _appointmentRepo.Add(appointment);
        }

        public async Task<List<string>> CheckAppointment(string requestId)
        {
            // gets list of free appointments
            // remove strings ahead
            var doctorId = requestId.Replace("/appointments/", "");

            return await _appointmentRepo.Check(doctorId);
        }
    }
}
