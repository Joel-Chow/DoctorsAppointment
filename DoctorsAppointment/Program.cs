var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* builder.Services.AddTransient<IDoctorAvailbilityRepository, DoctorAvailabilityInMemory>();
builder.Services.AddTransient<IDoctorsService, DoctorsService>(); */

var app = builder.Build();

app.MapGet("/", () => "Doctor's Appointment Scheduling");

app.Run();
