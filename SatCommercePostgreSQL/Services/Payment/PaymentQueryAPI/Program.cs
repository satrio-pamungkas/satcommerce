using Microsoft.EntityFrameworkCore;
using PaymentQueryAPI.Consumers;
using PaymentQueryAPI.Data;
using PaymentQueryAPI.Handlers;
using PaymentQueryAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);
var dbString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(dbString));
builder.Services.AddHostedService<PaymentTopicConsumer>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentHandler, PaymentHandler>();

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