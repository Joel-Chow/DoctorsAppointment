using DoctorsAppointment.Entities;
using DoctorsAppointment.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointment.Controllers;

[Route("/appointments")]
public class AppointmentController : ControllerBase
{ 
    
    private readonly IPaitentAppointmentService _appointmentService;
    public AppointmentController(IPaitentAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    public async Task<IActionResult> Post([FromBody] Appointment appointment) 
    {

        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(value => value.Errors)
                .Select(error => error.ErrorMessage)
                .ToList();
            return BadRequest(errors);
        }

        await _appointmentService.CreateAppointment(appointment);
        return Ok("Appointment Booked!");
    }
    
}
