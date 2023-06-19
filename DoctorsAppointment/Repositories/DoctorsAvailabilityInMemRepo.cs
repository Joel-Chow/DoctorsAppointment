using System;
using DoctorsAppointment.Entities;
using DoctorsAppointment.Repositories;

public class CatetgoryInMemoryRepo : IDoctorsAvailabilityRepo
{
    private static List<DoctorAvailability> _doctorAvailability = new List<DoctorAvailability>();

    public async Task Add(DoctorAvailability doctorAvailability)
    {
        _doctorAvailability.Add(doctorAvailability);
    }

    public bool SlotExist(bool isReserved)
    {
        return _doctorAvailability.Any(x => x.IsReserved == isReserved);
    }
}

