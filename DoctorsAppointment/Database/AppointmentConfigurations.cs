using DoctorsAppointment.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAppointment.Database
{
    public class AppointmentConfigurations : IEntityTypeConfiguration<PaitentBooking>
    {
        public void Configure(EntityTypeBuilder<PaitentBooking> builder)
        {
            builder.HasKey(x => x.Id);


        }
    }
}
