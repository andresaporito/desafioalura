using Desafio.Alura.Domain.Interfaces.Respositories;
using Desafio.Alura.Domain.Interfaces.Services;
using Desafio.Alura.Infra.Context;
using Desafio.Alura.Infra.Repositories;
using Desafio.Alura.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqLite")));

builder.Services.AddScoped<IAutomationService, AutomationService>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();

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
