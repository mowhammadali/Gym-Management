using GymManagement.Application;
using GymManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(configuration);
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();