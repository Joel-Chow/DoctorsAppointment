using System.Runtime.Serialization;

namespace DoctorsAppointment.Services.Exceptions
{
    [Serializable]
    internal class NegativeCostException : Exception
    {

        public NegativeCostException() : base("Cost should not be negative!")
        {
        }

    }
}