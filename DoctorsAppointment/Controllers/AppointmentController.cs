using DoctorsAppointment.Entities;
using DoctorsAppointment.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointment.Controllers
{
    [Route("/appointments/{doctorId}")]
    public class AppointmentController : ControllerBase
    {
        private readonly IPaitentAppointmentService _appointmentService;
        private readonly ILogger<AppointmentController> _logger;
        public AppointmentController(IPaitentAppointmentService appointmentService, ILogger<AppointmentController> logger)
        {
            _appointmentService = appointmentService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaitentBooking appointment, string doctorId)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }

            var requestId = doctorId;

            await _appointmentService.CreateAppointment(appointment, doctorId);
            return Ok("Appointment Booked!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAction([FromBody] HttpContext content)
        {
            var requestId = HttpContext.Request.Path;

            _logger.LogInformation("Fetching doctor's schedule");

            var message = "Here are the Doctor's free appointments!\n";
            var results = await _appointmentService.CheckAppointment(requestId);
            foreach (var result in results)
            {
                message = message + result + "\n";
            }

            return Ok(message);
        }
    }
}