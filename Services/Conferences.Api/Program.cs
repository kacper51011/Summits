using Conferences.Api.Extensions;
using Conferences.Application.Commands.Conferences;
using Conferences.Domain.Interfaces;
using Conferences.Infrastructure.Db;
using Conferences.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMediatR((o)=> o.RegisterServicesFromAssemblyContaining(typeof(CreateConferenceCommand)));

builder.Services.AddSingleton<IConferenceRepository, ConferenceRepository>();

// because this project serves as an example, i decided to not store my passes locally,
//
builder.Services.RegisterDb();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
