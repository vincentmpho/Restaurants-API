using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders.Interfaces;
using Restaurants.Application.Extensions;
using Serilog;
using Serilog.Events;
using Restaurants_API.Middlewares;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register infrastructure services
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

// Configure Serilog
builder.Host.UseSerilog((context, configuration) =>
     configuration
   .ReadFrom.Configuration(context.Configuration)
);

//Register RequestTileLoggingMiddlewar
builder.Services.AddScoped<RequestTimeLoggingMiddleware> ();

var app = builder.Build();

 var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IResturantSeeder>();

await seeder.Seed();

// Configure the HTTP request pipeline.'
app.UseMiddleware<RequestTimeLoggingMiddleware>();
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
