using minecraftServers.Models;


namespace minecraftServers.Repositories;

public class ServersReposirory : IServersRepository
{
    private readonly List<Server> _servers = new();
    public Server Add(CustomServer server)
    {
        Random random = new Random();
        int serverOnline = random.Next(0, 999);
        var newServer = new Server(server.Ip, serverOnline, server.Name);
        _servers.Add(newServer);
        return newServer;

    }

    public bool Delete(string ip)
    {
       var servName = _servers.FirstOrDefault(x => x.Ip == ip);
        _servers.Remove(servName);
        return true;
    }

    public List<Server> GetAll()
    {
        return _servers;
    }
    public Server GetIp(string ip)
    {
       return _servers.FirstOrDefault(x => x.Ip == ip);
    }
    public Server GetName(string name)
    {
        return _servers.FirstOrDefault(x => x.Name == name);
    }
}
