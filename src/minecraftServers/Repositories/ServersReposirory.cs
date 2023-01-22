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
        server.Online = random.Next(0, 1000);
        _db.Add(server);
        _db.SaveChanges();
        return server;
    }


    public bool Delete(int id)
    {
       var servName = _db.Servers.FirstOrDefault(x => x.Id == id);
        if (servName == null)
            return false;
        _db.Remove(servName);
        _db.SaveChanges();
        return true;
    }

    public IEnumerable<Server> GetAll() { return _db.Servers.AsNoTracking().ToArray(); }

    public Server? GetByIp(string ip) { return _db.Servers.AsNoTracking().FirstOrDefault(x => x.Ip == ip); }

    public Server? GetName(string name) { return _db.Servers.AsNoTracking().FirstOrDefault(x => x.Name == name); }

    public Server? GetById(int id) { return _db.Servers.AsNoTracking().FirstOrDefault(x => x.Id == id); }
}
