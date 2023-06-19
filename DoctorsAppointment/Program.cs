using DoctorsAppointment.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IDoctorsAvailabilityRepo, CatetgoryInMemoryRepo>();

var app = builder.Build();

app.MapGet("/", () => "Doctor's Appointment Scheduling");

app.Run();
