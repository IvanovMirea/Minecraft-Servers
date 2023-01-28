namespace MinecraftServers.Repositories;

using MinecraftServers.Dto;
using MinecraftServers.Models;

public interface IServersRepository
{
    IEnumerable<Server> GetAll();

    bool Delete(int id);

    Server Add(Server server);

    Server GetByIp(string ip);

    Server GetName(string name);

    Server GetById(int id);

    Server? Update(ServerDto server, int id);

}
