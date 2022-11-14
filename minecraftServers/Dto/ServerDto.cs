namespace MinecraftServers.Models;

public class ServerDto
{
    public ServerDto(string ip, string name)
    {
        Ip = ip;
        Name = name;
    }
    public string Ip { get; set; }
    public string Name { get; set; }
}
