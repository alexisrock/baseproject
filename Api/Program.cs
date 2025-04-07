using System.Reflection;
using Api.Middlewares;
using Application.UseCases.ProductoCreate;
using Infrastructure.Configuration;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("https://alexisrock.github.io")
        .WithOrigins("http://localhost:4200")// 👈 Permite Angular
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Solo si usas autenticación basada en cookies o sesiones
    });
});

builder.Services.AddDbContext<PruebaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BdEM"),
    sqlServerOptionsAction: options =>
    {
        options.EnableRetryOnFailure();
    });

});
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(typeof(ProductoCreateHandler).GetTypeInfo().Assembly);
});
builder.Services.AddHealthChecks();
builder.Services.ConfigureRepository();
builder.Services.ConfigureServices();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
app.MapHealthChecks("/health");
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();
 

app.MapControllers();

app.Run();
