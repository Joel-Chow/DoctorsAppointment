using DoctorsAppointment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsAppointment.Database
{
    public class DoctorsConfigurations : IEntityTypeConfiguration<Slot>

    {
        public void Configure(EntityTypeBuilder<Slot> builder)
        {
            // builder.ToTable("Doctors");
            builder.HasKey(x => x.Id);
        }
    }
}
