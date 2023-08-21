using System.Text;
using Microsoft.OpenApi.Models;
using LixTec.Platform.Common.Entity;
using LixTec.Api.Application.Filters;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using LixTec.Platform.Auth.Infrastructure.DependencyInjection.Extensions;
using LixTec.Platform.Business.Infrastructure.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<ExceptionFilter>());

Settings settings = builder.Configuration.GetSection("Settings").Get<Settings>();

builder.Services.AddSingleton(options => settings);

var key = Encoding.ASCII.GetBytes(settings.JwtSecret);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };
    });

builder.Services.AddSwaggerGen(c =>
    {
        var securityScheme = new OpenApiSecurityScheme
        {
            Name = "JWT Authentication",
            Description = "Enter JWT Bearer token **_only_**",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            Reference = new OpenApiReference
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };

        c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {securityScheme, new string[] { }}
        });
    });

builder.Services.AddScopedAuthFactories();
builder.Services.AddScopedBusinessFactories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .WithHeaders("Accept", "Accept-Language", "Content-Language", "Content-Type", "Authorization", "Cookie", "Origin", "Host", "x-application-key", "x-application-token")
    .WithExposedHeaders("x-application-token", "x-license-key"));

app.UseAuthorization();

app.MapControllers();

app.Run();
