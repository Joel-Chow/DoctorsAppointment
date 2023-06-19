﻿using DoctorsAppointment.Controllers.Dtos;
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
        public async Task<IActionResult> Post([FromBody] CreateDoctorsAvailability request)
        {
            await _doctorsAvailabilityService.Create(
                request.DoctorName,
                request.IsReserved,
                request.Cost
                );

            return Ok("Slot Created!");
        }
    }
}
