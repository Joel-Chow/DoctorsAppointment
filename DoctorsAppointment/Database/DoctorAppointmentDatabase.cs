using DoctorsAppointment.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAppointment.Database
{
    public class DoctorAppointmentDatabase: DbContext
    {
        public DbSet<Slot> DoctorAvailabilities { get; set; }
        public DbSet<PaitentBooking> PaitentBooking { get; set; }

        public DoctorAppointmentDatabase(DbContextOptions<DoctorAppointmentDatabase> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Doctors_Appointment_Db");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    
    }

    public static class DbExtension
    {
        public static IServiceCollection AddDoctorsAppointmentDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DoctorAppointmentDatabase>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Postgres"));
            });
            return services;
        }
    }
}
