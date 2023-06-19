using System.Runtime.Serialization;
namespace DoctorsAppointment.Services
{
    [Serializable]
    internal class SlotAlreadyExistsException : Exception
    {
        public SlotAlreadyExistsException(DateTime date) : base($"Slot with time {date} already exist!")
        {
        }
    }
}