using DoctorsAppointment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsAppointment.Database
{
    public class DoctorsConfigurations : IEntityTypeConfiguration<DoctorAvailability>

    {
        public void Configure(EntityTypeBuilder<DoctorAvailability> builder)
        {
            builder.ToTable("Doctors");
            builder.HasKey(x => x.Id);
        }
    }
}
