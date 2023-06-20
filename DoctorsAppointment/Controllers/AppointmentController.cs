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

    
    public async Task<IActionResult> GetAction(Appointment appointment)
    {
        var message = "Here are the free appointments!\n";
        var results = await _appointmentService.CheckAppointment(appointment);
        foreach (var result in results)
        {
            message = message + result + "\n";
        }
        
        return Ok(message);
    }
}
