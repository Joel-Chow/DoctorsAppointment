using DoctorsAppointment.Database;
using DoctorsAppointment.Repositories;
using DoctorsAppointment.Security;
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

builder.Services.AddDoctorAppointmentAuthentication(builder.Configuration);
builder.Services.AddDoctorsAppointmentDb(builder.Configuration);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));
builder.Services.AddTransient<JwtCreator>();

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
