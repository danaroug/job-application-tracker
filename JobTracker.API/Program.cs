using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add CORS service and allow your React frontend origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000") // React dev server URL
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Register DbContext BEFORE builder.Build()
builder.Services.AddDbContext<JobContext>(options =>
    options.UseSqlite("Data Source=jobs.db")); // Or UseSqlServer(...)

// Add controllers, swagger, etc
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS BEFORE routing or authorization middleware
app.UseCors("AllowReactApp");

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Seed the database with sample jobs if empty
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<JobContext>();

    if (!context.Jobs.Any())
    {
        context.Jobs.AddRange(
            new Job { Title = "Software Engineer", Company = "Acme Corp", Status = "Applied" },
            new Job { Title = "Web Developer", Company = "Beta LLC", Status = "Wishlist" },
            new Job { Title = "Project Manager", Company = "Gamma Inc", Status = "Interview" }
        );
        context.SaveChanges();
    }
}

app.Run();

