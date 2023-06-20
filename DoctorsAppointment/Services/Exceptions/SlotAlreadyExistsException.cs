using System.Runtime.Serialization;

namespace DoctorsAppointment.Services.Exceptions
{
    [Serializable]
    internal class SlotAlreadyExistsException : Exception
    {
        public SlotAlreadyExistsException(bool isReserved) : base($"Slot already exist!")
        {
        }
    }
}