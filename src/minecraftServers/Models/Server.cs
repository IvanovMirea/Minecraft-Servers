﻿namespace MinecraftServers.Models;

public class Server
{
    public Server(string ip, int online, string name, int id)
    {
        Id = id;
        Ip = ip;
        Online = online;
        Name = name;
    }
    
    public string Ip { get; set; }
    public int Online { get; set; }
    public string Name { get; set; }
    public int Id { get; set; }
}

