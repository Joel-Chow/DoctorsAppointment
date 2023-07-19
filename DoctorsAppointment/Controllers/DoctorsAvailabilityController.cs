using System;
using DoctorsAppointment.Entities;
using DoctorsAppointment.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointment.Controllers
{
    [Route("/slots/{doctorId}")]
    public class DoctorsAvailabilityController : ControllerBase
    {
        private readonly IDoctorsAvailabilityService _doctorsAvailabilityService;
        public DoctorsAvailabilityController(IDoctorsAvailabilityService doctorsAvailabilityService)
        {
            _doctorsAvailabilityService = doctorsAvailabilityService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Slot slot, string doctorId)
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

            await _doctorsAvailabilityService.Create(slot, doctorId);

            return Ok("Slot Created!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAction([FromBody] HttpContext content)
        {

            /*if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }*/
            var requestId = HttpContext.Request.Path;

            var message = "Hi Doctor! Here are your free appointments!\n";
            var results = await _doctorsAvailabilityService.CheckAppointment(requestId);
            foreach (var result in results)
            {
                message = message + result + "\n";
            }

            return Ok(message);
        }
    }
}

