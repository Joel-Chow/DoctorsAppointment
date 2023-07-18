using System;
using DoctorsAppointment.Entities;
using DoctorsAppointment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            await _doctorsAvailabilityService.Create(slot);

            return Ok("Slot Created!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAction([FromBody] Slot slot, string doctorId)
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

            var message = "Hi Doctor! Here are your appointments!\n";
            var results = await _doctorsAvailabilityService.CheckAppointment(slot.DoctorName);
            foreach (var result in results)
            {
                message = message + result + "\n" + requestId;
            }

            return Ok(message);
        }
    }
}

