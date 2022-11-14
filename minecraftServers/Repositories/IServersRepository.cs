namespace MinecraftServers.Repositories;

using MinecraftServers.Models;

public interface IServersRepository
{
    List<Server> GetAll();

    bool Delete(uint id);

    Server Add(ServerDto server);

    Server GetByIp(string ip);

    Server GetName(string name);

    Server GetById(uint id);

    Server AddUnique(ServerDto server, uint id);
}
