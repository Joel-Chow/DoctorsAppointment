using System;
using DoctorsAppointment.Entities;
using DoctorsAppointment.Repositories;

public class CatetgoryInMemoryRepo : IDoctorsAvailabilityRepo
{
    private static List<DoctorAvailability> _doctorAvailability = new List<DoctorAvailability>();

    public async Task Add(DoctorAvailability slot)
    {
        _doctorAvailability.Add(slot);
    }

    public bool SlotExist(DateTime date)
    {
        return _doctorAvailability.Any(x => x.Date == date);
    }
}

