using System.Runtime.Serialization;

namespace DoctorsAppointment.Services
{
    [Serializable]
    internal class DoctorNameExistsException : Exception
    {

        public DoctorNameExistsException(string doctorName) : base("Doctor with name {doctorName} already exists..")
        {
        }
    }
}