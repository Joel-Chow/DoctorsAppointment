using DoctorsAppointment.Repositories;
using DoctorsAppointment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IDoctorsAvailabilityRepo, CatetgoryInMemoryRepo>();
builder.Services.AddTransient<IDoctorsAvailabilityService, DoctorsAvailabilityService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Doctor's Appointment Scheduling");
app.MapControllers();

app.Run();
