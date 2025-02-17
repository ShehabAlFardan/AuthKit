using AuthKit.Domain.UserAggregate;
using AuthKit.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


#region Migrations

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();

var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await applicationDbContext.Database.MigrateAsync();
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while migrating the database.");
    throw;
}

#endregion
app.Run();
