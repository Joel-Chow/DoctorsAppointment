using DoctorsAppointment.DoctorsAppointment.Authentication;
using DoctorsAppointment.DoctorsAppointment.Management;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDoctorsSlot()
    .AddAuthenticationModule(builder.Configuration);

builder.Services.AddControllers();


var app = builder.Build();

app.MapGet("/", () => "Doctor's Appointment Scheduling"); 
app.UseHttpLogging();

app.MapControllers();

app.Run();
