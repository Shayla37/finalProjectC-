// FILE: Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Enables Controller usage

// Add CORS policy to allow the index.html page to call the API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder =>
        {
            builder.AllowAnyOrigin() 
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowFrontend");

// Map controllers to handle routes (e.g., /api/oop)
app.MapControllers(); 

app.Urls.Add("http://localhost:5000");
Console.WriteLine("C# Backend running on http://localhost:5000");

app.Run();
