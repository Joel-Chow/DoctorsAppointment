﻿using System;
using DoctorsAppointment.Entities;
using DoctorsAppointment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointment.Controllers
{
    [Route("/slots/{doctorId}")]
    public class DoctorsAvailabilityController : ControllerBase
    {
        private readonly IDoctorsAvailabilityService _doctorsAvailabilityService;
        private readonly ILogger<DoctorsAvailabilityController> _logger;
        public DoctorsAvailabilityController(IDoctorsAvailabilityService doctorsAvailabilityService, ILogger<DoctorsAvailabilityController> logger)
        {
            _doctorsAvailabilityService = doctorsAvailabilityService;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> GetAction([FromBody] HttpContext content)
        {

            var requestId = HttpContext.Request.Path;

            _logger.LogInformation("Request received");

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

