using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DoctorsAppointment.DoctorsAppointment.Authentication.Security
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddDoctorAppointmentAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtOptions jwtConfig = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>()!;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtConfig.Issuer,
                        ValidAudience = jwtConfig.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            return services;
        }
    }
}
