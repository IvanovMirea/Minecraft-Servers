using MinecraftServers.Repositories;
using MinecraftServers.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IServersRepository, ServersReposirory>();
builder.Services.AddDbContext<ServerContext>(option =>
{
    option.UseInMemoryDatabase("servers-db");
});

var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
