
using DoctorsAppointment.DoctorsAppointment.Authentication.Security;

namespace DoctorsAppointment.DoctorsAppointment.Authentication
{
    public static class Extensions
    {
        public static IServiceCollection AddAuthenticationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
            services
                .AddDoctorAppointmentAuthentication(configuration)
                .AddTransient<JwtCreator>();
            return services;
        }
    }
}
