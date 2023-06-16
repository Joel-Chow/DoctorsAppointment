var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

app.MapGet("/", () => "Doctor's Appointment Scheduling");

app.Run();
