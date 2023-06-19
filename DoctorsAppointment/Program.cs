using DoctorsAppointment.Database;
using DoctorsAppointment.Repositories;
using DoctorsAppointment.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDoctorsAppointmentDb(builder.Configuration);

// Add services to the container.
builder.Services.AddTransient<IDoctorsAvailabilityRepo, CatetgoryInMemoryRepo>();
builder.Services.AddTransient<IDoctorsAvailabilityService, DoctorsAvailabilityService>();

builder.Services.AddTransient<IAppointmentRepo, AppointmentInMemRepo>();
builder.Services.AddTransient<IPaitentAppointmentService, PaitentAppointmentService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Doctor's Appointment Scheduling");
app.MapControllers();

app.Run();
