/*using DoctorsAppointment.Entities;
using DoctorsAppointment.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointment.Controllers;

[Route("bookings")]
public class BookingController : ControllerBase
{
    private readonly IPaitentAppointmentService _appointmentService;
    public AppointmentController(IPaitentAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    public async Task<IActionResult> Post([FromBody] Appointment appointment)
    {
        return await _database.DoctorAvailabilities.Where(x => x.IsReserved == true).ToListAsync();
    }
}

*/