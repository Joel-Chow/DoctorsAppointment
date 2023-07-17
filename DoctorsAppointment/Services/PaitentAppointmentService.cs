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

        public async Task<List<string>> CheckAppointment(PaitentBooking appointment)
        {
            // gets list of free appointments
            return await _appointmentRepo.Check(appointment);
        }
    }
}
