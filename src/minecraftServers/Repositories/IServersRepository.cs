namespace MinecraftServers.Repositories;

using MinecraftServers.Models;

public interface IServersRepository
{
    IEnumerable<Server> GetAll();

    bool Delete(uint id);

    Server Add(Server server);

    Server GetByIp(string ip);

    Server GetName(string name);

    Server GetById(uint id);

    Server AddUnique(Server server, uint id);
}
