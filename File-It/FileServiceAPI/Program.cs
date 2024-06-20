using FileServiceAPI.Interfaces;
using FileServiceAPI.Messaging;
using FileServiceAPI.Repos;
using Microsoft.Extensions.DependencyInjection;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

FileRepo filerepo = new(builder.Configuration);

builder.Services.AddScoped<IFileRepo>(provider => {
    return filerepo;
});

var app = builder.Build();

ReceiveMessage.CreateChannel(filerepo, builder.Configuration);

app.UseHttpMetrics();
app.UseMetricServer();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapMetrics();

app.Run();
