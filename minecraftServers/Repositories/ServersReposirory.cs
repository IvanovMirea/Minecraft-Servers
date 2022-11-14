using MinecraftServers.Models;

namespace MinecraftServers.Repositories;

public class ServersReposirory : IServersRepository
{
    private readonly List<Server> _servers = new();
    public Server Add(ServerDto server)
    {
        Random random = new Random();
        uint id = 0;
        int serverOnline = random.Next(0, 999);
        var newServer = new Server(server.Ip, serverOnline, server.Name, id);
        if (_servers.Count == 0)
        {
            _servers.Add(newServer);
            return newServer;
        }
        var newId = _servers.Last().Id + 1;
        var nextServer = new Server(server.Ip, serverOnline, server.Name, newId);
        _servers.Add(nextServer);
        return nextServer;

    }

    public Server AddUnique(ServerDto server, uint id)
    {
        Random random = new Random();
        int serverOnline = random.Next(0, 999);
        var newServer = new Server(server.Ip, serverOnline, server.Name, id);
        _servers.Add(newServer);
        return newServer;
    }

    public bool Delete(uint id)
    {
       var servName = _servers.FirstOrDefault(x => x.Id == id);
        if (servName == null)
            return false;
        _servers.Remove(servName);
        return true;
    }

    public List<Server> GetAll()
    {
        return _servers;
    }
    public Server? GetByIp(string ip)
    {
       return _servers.FirstOrDefault(x => x.Ip == ip);
    }
    public Server? GetName(string name)
    {
        return _servers.FirstOrDefault(x => x.Name == name);
    }
    public Server? GetById(uint id)
    {
        return _servers.FirstOrDefault(x => x.Id == id);
    }
}
