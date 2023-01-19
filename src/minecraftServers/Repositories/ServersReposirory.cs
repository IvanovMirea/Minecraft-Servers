using MinecraftServers.Models;
using MinecraftServers.Data;
using Microsoft.EntityFrameworkCore;

namespace MinecraftServers.Repositories;

public class ServersReposirory : IServersRepository
{
    private readonly ServerContext _db;

    public ServersReposirory(ServerContext context)
    {
        _db = context;
    }
    public Server Add(Server server)
    {
        Random random = new Random();
        int serverOnline = random.Next(0, 999);
        int numberOfServers = _db.Servers.Count();
        var nextServer = new Server(server.Ip, serverOnline, server.Name, server.Id);
        _db.Add(nextServer);
        _db.SaveChanges();
        return nextServer;

    }

    public Server AddUnique(Server server, uint id)
    {
        Random random = new Random();
        int serverOnline = random.Next(0, 999);
        var newServer = new Server(server.Ip, serverOnline, server.Name, id);
        _db.Add(newServer);
        _db.SaveChanges();
        return newServer;
    }

    public bool Delete(uint id)
    {
       var servName = _db.Servers.FirstOrDefault(x => x.Id == id);
        if (servName == null)
            return false;
        _db.Remove(servName);
        _db.SaveChanges();
        return true;
        
    }

    public IEnumerable<Server> GetAll()
    {
        return _db.Servers.AsNoTracking().ToArray();
    }
    public Server? GetByIp(string ip)
    {
       return _db.Servers.AsNoTracking().FirstOrDefault(x => x.Ip == ip);
    }
    public Server? GetName(string name)
    {
        return _db.Servers.AsNoTracking().FirstOrDefault(x => x.Name == name);
    }
    public Server? GetById(uint id)
    {
        return _db.Servers.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }
}
