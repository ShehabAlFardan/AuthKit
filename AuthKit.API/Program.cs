using AuthKit.API.Middlewares;
using AuthKit.Application.ApplicationAggregate.Queries;
using AuthKit.Application.ApplicationAggregate.Validations;
using AuthKit.Application.DashboardAggregate.Commands;
using AuthKit.Application.DashboardAggregate.Queries;
using AuthKit.Application.DashboardAggregate.Validations;
using AuthKit.Application.OrganizationAggregate.Validations;
using AuthKit.Application.Services;
using AuthKit.Domain.ApplicationAggregate;
using AuthKit.Domain.DashbaordAggregate;
using AuthKit.Domain.OrganizationAggregate;
using AuthKit.Domain.UserAggregate;
using AuthKit.Infrastructure.Integration.DashboardAggregate.JWT;
using AuthKit.Infrastructure.Integration.DashboardAggregate.JWT.Services;
using AuthKit.Infrastructure.Persistance;
using AuthKit.Infrastructure.Persistance.ApplicationAggregate.Queries;
using AuthKit.Infrastructure.Persistance.ApplicationAggregate.Repositories;
using AuthKit.Infrastructure.Persistance.DashboardAggregate.Queries;
using AuthKit.Infrastructure.Persistance.DashboardAggregate.Repositories;
using AuthKit.Infrastructure.Persistance.OrganizationAggregate.Repositories;
using AuthKit.Infrastructure.Persistance.UserAggregate.Repositories;
using AuthKit.Infrastructure.Validation.Fluent.ApplicationAggregate;
using AuthKit.Infrastructure.Validation.Fluent.DashboardAggregate;
using AuthKit.Infrastructure.Validation.Fluent.OragnizationAggregate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region ApplicationAggregate

builder.Services.AddScoped<IApplicationRepository, ApplicationEfRepository>();
builder.Services.AddScoped<ICreateApplicationCommandValidator, CreateApplicationFluentValidator>();
builder.Services.AddScoped<IUpdateApplicationCommandValidator, UpdateApplicationFluentValidator>();
builder.Services.AddScoped<IDeleteApplicationCommandValidator, DeleteApplicationFluentValidator>();
builder.Services.AddScoped<IApplicationQueries, ApplicationQueries>();
#endregion

#region DashboardAggregate

builder.Services.AddScoped<IDashboardUserRepository, DashboardUserEfRepository>();
builder.Services.AddScoped<ICreateDashboardUserCommandValidator, CreateDashboardUserCommandFluentValidator>();
builder.Services.AddScoped<IDashboardUserQueries, DashboardUserQueries>();
builder.Services.AddScoped<ILoginDashboardUserCommandValidator, LoginDashboardUserCommandFluentValidator>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

#endregion

#region OrganizationAggregate
builder.Services.AddScoped<ICreateOrganizationCommandValidator, CreateOrganizationCommandFluentValidator>();

builder.Services.AddScoped<IOrganizationRepository, OrganizationEfRepository>();

#endregion

#region UserAggregate

builder.Services.AddScoped<IUserRepository, UserEfRepository>();

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter 'Bearer {your token}'"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
        var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateDashboardUserCommand).Assembly));


builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
});


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
//app.UseMiddleware<UserClaimsMiddleware>();


app.UseAuthentication();
app.UseAuthorization();

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
