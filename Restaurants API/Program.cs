using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders.Interfaces;
using Restaurants.Application.Extensions;
using Serilog;
using Restaurants.Domain.Models;
using Restaurants_API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Register infrastructure services
builder.Services.AddInfrastructure(builder.Configuration);

builder.AddPresentation();

// Register application services
builder.Services.AddApplication();

var app = builder.Build();

// Create a scope for seeding initial data
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IResturantSeeder>();

// Seed initial data
await seeder.Seed();

// Configure the HTTP request pipeline
// Enable Serilog request logging
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map API endpoints for identity
app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
