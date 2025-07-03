using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Shared.Application;
using Mappings.SharedMappings;
using Shared.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Shared.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Configure EF Core DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // 2. Add AutoMapper with shared mappings
        services.AddAutoMapper(typeof(SharedMappings));

        // 3. Register application-level scoped services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IDeveloperSettingsService, DeveloperSettingsService>();
        services.AddScoped<IDepartmentSettingsService, DepartmentSettingsService>();
        services.AddScoped<IApplicantService, ApplicantService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IGeneralFormFieldService, GeneralFormFieldService>();

        // 4. JWT Authentication setup with cookie token fallback
        var jwtKey = configuration["Jwt:Key"] 
            ?? throw new InvalidOperationException("Jwt:Key is missing in configuration.");
        var jwtIssuer = configuration["Jwt:Issuer"] 
            ?? throw new InvalidOperationException("Jwt:Issuer is missing in configuration.");
        var jwtAudience = configuration["Jwt:Audience"] 
            ?? throw new InvalidOperationException("Jwt:Audience is missing in configuration.");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Cookies["access_token"];
                        if (!string.IsNullOrWhiteSpace(accessToken))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
                options.Events = new JwtBearerEvents
{
    OnChallenge = context =>
    {
        context.HandleResponse(); 
        context.Response.StatusCode = 401;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync("{\"error\": \"Unauthorized access\"}");
    }
};
    });

services.AddAuthentication("MyCookieScheme")
    .AddCookie("MyCookieScheme", options =>
    {
        // options.LoginPath = "/login"; // optional
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
        options.Events.OnRedirectToAccessDenied = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };
    });


        services.ConfigureApplicationCookie(options =>
    {
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };

        options.Events.OnRedirectToAccessDenied = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };
    });




        return services;
    }
}

