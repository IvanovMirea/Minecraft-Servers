namespace minecraftServers.Models;

public class Server
{
    public Server(string ip, int online, string name)
    {
        Ip = ip;
        Online = online;
        Name = name;
    }

    public string Ip { get; set; }
    public int Online { get; set; }
    public string Name { get; set; }

}
