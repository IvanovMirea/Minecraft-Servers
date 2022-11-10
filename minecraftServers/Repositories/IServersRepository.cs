namespace minecraftServers.Repositories;

using minecraftServers.Models;
public interface IServersRepository
{
    List<Server> GetAll();

    bool Delete(string ip);

    Server Add(CustomServer server);

    Server GetIp(string ip);

    Server GetName(string name);
}
