namespace minecraftServers.Models;

public class CustomServer
{
    public CustomServer(string ip, string name)
    {
        Ip = ip;
        Name = name;
    }
    public string Ip { get; set; }
    public string Name { get; set; }
}
