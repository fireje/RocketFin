using Refit;
using RocketFin.Api.Infrastructure.Services;
using RocketFin.Api.Persistance.Context;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RocketFin.Api.Interfaces;
using RocketFin.Api.Persistance.Repositories;
using RocketFin.Api.Domain;
using RocketFin.Api.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContext<RocketFinDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("RocketFinDB")));


var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();



// Add services to the container.
builder.Services.AddCors(options =>
{
	options.AddPolicy("myAppCors", policy =>
	{
		policy.WithOrigins(allowedOrigin)
				.AllowAnyHeader()
				.AllowAnyMethod();
	});
});

var apiSettings = builder.Configuration.GetSection("APISettings").Get<APISettings>();

builder.Services.AddRefitClient<IYHFinanceAPI>()
	.ConfigureHttpClient(c =>
	{
		c.BaseAddress = new Uri(apiSettings.URL);
		c.DefaultRequestHeaders.Add("X-API-KEY", apiSettings.APIKEY);
	});


builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
	app.UseSwagger();
	app.UseSwaggerUI();

//}

app.UseCors("myAppCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
