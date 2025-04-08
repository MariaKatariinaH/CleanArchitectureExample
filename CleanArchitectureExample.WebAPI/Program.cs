using CleanArchitectureExample.Application.Interfaces;
using CleanArchitectureExample.Application.Services;
using CleanArchitectureExample.Domain.Interfaces;
using CleanArchitectureExample.Infrastructure.Data;
using CleanArchitectureExample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("CleanArchitectureDb"));

builder.Services.AddScoped<IGreetingService, GreetingService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRegistrationService, UserRegistrationService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
