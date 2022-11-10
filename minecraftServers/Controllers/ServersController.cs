using Microsoft.AspNetCore.Mvc;
using minecraftServers.Repositories;
using minecraftServers.Models;
using System.Text.RegularExpressions;

namespace minecraftServers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServersController : ControllerBase
{
    private readonly IServersRepository _serversRep;
    private readonly Regex ip = new(@"(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|2[0-4]\d|25[0-5])");
    public ServersController(IServersRepository serverRep)
    {
        _serversRep = serverRep;
    }

    [HttpGet]
    public ActionResult<List<Server>> GetAll()
    {
        return Ok(_serversRep.GetAll());
    }

    [HttpPost]
    public ActionResult<Server> Add(CustomServer server)
    { 
        Server? serversIp = _serversRep.GetIp(server.Ip);
        if (!ip.IsMatch(server.Ip))
        {
            return BadRequest("Ip is incorrect !");
        }
        if (serversIp != null)
        {
            return NotFound("This server already exist !");
        }
        return Ok(_serversRep.Add(server));
    }

    [HttpDelete("{ip}")]
    public ActionResult Delete(string ip)
    {
        Server? serversIp = _serversRep.GetIp(ip);
        _serversRep.Delete(ip);
        if (serversIp == null)
        {
            return NotFound("We cannot find this server :(");
        }
        return Ok();
    }
}
