using MinecraftServers.Models;
using MinecraftServers.Data;
using Microsoft.EntityFrameworkCore;
using MinecraftServers.Dto;

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
    
    public Server? Update(ServerDto server, int id)
    {
        var changedEntity = _db.Servers.FirstOrDefault(x => x.Id == id);
        if (changedEntity == null)
        {
            return null;
        }
        changedEntity.Ip = server.Ip;
        changedEntity.Name = server.Name;
        _db.SaveChanges();
        return changedEntity;
    }

    public IEnumerable<Server> GetAll() => _db.Servers.AsNoTracking().ToArray();

    public Server? GetByIp(string ip) => _db.Servers.AsNoTracking().FirstOrDefault(x => x.Ip == ip);

    public Server? GetName(string name) => _db.Servers.AsNoTracking().FirstOrDefault(x => x.Name == name); 

    public Server? GetById(int id) => _db.Servers.AsNoTracking().FirstOrDefault(x => x.Id == id);
}
