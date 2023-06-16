using System.Runtime.Serialization;

namespace DoctorsAppointment.Services
{
    [Serializable]
    internal class DoctorNameException : Exception
    {

        public DoctorNameException() : base("Doctor's Name should be filled in..")
        {
        }

    }
}