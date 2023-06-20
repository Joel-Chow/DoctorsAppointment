using System.Runtime.Serialization;

namespace DoctorsAppointment.Services.Exceptions
{
    [Serializable]
    internal class DoctorNameEmptyException : Exception
    {
        public DoctorNameEmptyException() : base("Doctor name should not be null")
        {
        }
    }
}