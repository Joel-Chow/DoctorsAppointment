﻿using System;

namespace DoctorsAppointment.Entities
{
    public class DoctorAvailability
    {
        public string? DoctorName { get; set; }
        public Guid DoctorId { get; set; }
        public string? Date { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
    }
}