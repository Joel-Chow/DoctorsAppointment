using System;
using DoctorsAppointment.Entities;
using DoctorsAppointment.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointment.Controllers
{
    [Route("/doctorsavailabilities")]
    public class DoctorsAvailabilityController : ControllerBase
    {
        private readonly IDoctorsAvailabilityService _doctorsAvailabilityService;
        public DoctorsAvailabilityController(IDoctorsAvailabilityService doctorsAvailabilityService) 
        {
            _doctorsAvailabilityService = doctorsAvailabilityService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DoctorAvailability availability)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }

            await _doctorsAvailabilityService.Create(availability);

            return Ok("Slot Created!");
        }
    }
}
