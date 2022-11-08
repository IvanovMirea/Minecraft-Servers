using minecraftServers.Servers;


namespace minecraftServers.Repositories;

public class ServersReposirory : IServersRepository
{
    private readonly List<ServerList> _servers = new();
    public ServerList Add(CustomServer server)
    {
        Random random = new Random();
        int serverOnline = random.Next(0, 999);
        var newServer = new ServerList(server.Ip, serverOnline, server.Name);
        _servers.Add(newServer);
        return newServer;

    }

    public bool Delete(CustomServer server)
    {
       var servName = _servers.FirstOrDefault(x => x.Name == server.Name);
        _servers.Remove(servName);
        return true;
    }

    public List<ServerList> GetAll()
    {
        return _servers;
    }
    public ServerList GetIp(string ip)
    {
       return _servers.FirstOrDefault(x => x.Ip == ip);
    }
    public ServerList GetName(string name)
    {
        return _servers.FirstOrDefault(x => x.Name == name);
    }
}
