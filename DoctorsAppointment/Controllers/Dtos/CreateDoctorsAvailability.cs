namespace DoctorsAppointment.Controllers.Dtos
{
    public class CreateDoctorsAvailability
    {
        public string? DoctorName { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }

    }
}
