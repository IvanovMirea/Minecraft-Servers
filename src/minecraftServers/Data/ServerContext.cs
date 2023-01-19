using MinecraftServers.Models;
using Microsoft.EntityFrameworkCore;
namespace MinecraftServers.Data;

public class ServerContext:DbContext
{
    public DbSet<Server> Servers => Set<Server>();
    public ServerContext(DbContextOptions options) : base(options) { }
    
}


