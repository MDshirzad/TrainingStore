
using Microsoft.Extensions.Configuration;
using StoreApi.Constants;
using StoreApi.MessageHandler;
using StoreApi.Model;
using StoreApi.Repo;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MessageBrokerHandler>(builder.Configuration.GetSection("RabbitMQ"));
 
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
