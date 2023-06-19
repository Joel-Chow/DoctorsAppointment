using System.Runtime.Serialization;
namespace DoctorsAppointment.Services
{
    [Serializable]
    internal class SlotAlreadyExistsException : Exception
    {
        public SlotAlreadyExistsException(bool isReserved) : base($"Slot already exist!")
        {
        }
    }
}