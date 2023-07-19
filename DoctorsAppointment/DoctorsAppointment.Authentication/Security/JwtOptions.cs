namespace DoctorsAppointment.DoctorsAppointment.Authentication.Security;

public record JwtOptions
{
    public static string SectionName = "Jwt";
    public string Issuer { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;
}
