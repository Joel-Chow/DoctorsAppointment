using DoctorsAppointment.Database;
using DoctorsAppointment.DoctorsAppointment.Authentication;
using DoctorsAppointment.DoctorsAppointment.Authentication.Security;
using DoctorsAppointment.Repositories;
using DoctorsAppointment.Services;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services);
});
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
});

// add authentication module
builder.Services.AddAuthenticationModule(builder.Configuration);

builder.Services.AddDoctorsAppointmentDb(builder.Configuration);

// Add services to the container.
builder.Services.AddTransient<IDoctorsAvailabilityRepo, DoctorsAvailabilityRepo>();
builder.Services.AddTransient<IDoctorsAvailabilityService, DoctorsAvailabilityService>();

builder.Services.AddTransient<IAppointmentRepo, AppointmentRepo>();
builder.Services.AddTransient<IPaitentAppointmentService, PaitentAppointmentService>();



builder.Services.AddControllers();


var app = builder.Build();

app.MapGet("/", () => "Doctor's Appointment Scheduling"); 
app.UseHttpLogging();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
