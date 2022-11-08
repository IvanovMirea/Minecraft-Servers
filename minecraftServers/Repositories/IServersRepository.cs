namespace minecraftServers.Repositories
{
    using minecraftServers.Servers;
    public interface IServersRepository
    {
        List<ServerList> GetAll();

        bool Delete(CustomServer server);

        ServerList Add(CustomServer server);

        ServerList GetIp(string ip);

        ServerList GetName(string name);
    }
}