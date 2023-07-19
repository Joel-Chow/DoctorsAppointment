using DoctorsAppointment.Database;
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
app.MapControllers();

app.Run();
