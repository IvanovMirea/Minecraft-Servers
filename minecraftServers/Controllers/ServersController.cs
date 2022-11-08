using Microsoft.AspNetCore.Mvc;
using minecraftServers.Repositories;
using minecraftServers.Servers;
using System.Text.RegularExpressions;

namespace minecraftServers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServersController : ControllerBase
{
    private readonly IServersRepository _serversRep;
    private readonly List<ServerList> _servers = new();
    public ServersController(IServersRepository serverRep)
    {
        _serversRep = serverRep;
    }

    [HttpGet]
    public ActionResult<List<ServerList>> GetAll()
    {
        return Ok(_serversRep.GetAll());
    }

    [HttpPost("/api/servers/add")]
    public ActionResult<ServerList> Add(CustomServer server)
    { 
        ServerList? servers = _serversRep.GetName(server.Name);
        ServerList? serversIp = _serversRep.GetIp(server.Ip);
        Regex ip = new Regex(@"(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|2[0-4]\d|25[0-5])");
        if (!ip.IsMatch(server.Ip))
        {
            return NotFound("Ip is incorrect !");
        }
        if (servers != null || serversIp != null)
        {
            return NotFound("This server already exist !");
        }
        return Ok(_serversRep.Add(server));
    }

    [HttpPost("/api/servers/delete")]
    public ActionResult Delete(CustomServer server)
    {
        ServerList? servers = _serversRep.GetName(server.Name);
        ServerList? serversIp = _serversRep.GetIp(server.Ip);
        _serversRep.Delete(server);
        if (servers == null || serversIp == null)
        {
            return NotFound("We cannot find this server :(");
        }
        return Ok();
    }
}
