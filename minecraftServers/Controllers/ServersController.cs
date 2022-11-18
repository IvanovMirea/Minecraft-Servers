using Microsoft.AspNetCore.Mvc;
using MinecraftServers.Repositories;
using MinecraftServers.Models;
using System.Text.RegularExpressions;

namespace MinecraftServers.Controllers;

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

    [HttpGet("{id}")]
    public ActionResult<Server> GetById(uint id)
    {
        if (_serversRep.GetById(id) == null)
            return NotFound("We can't find this server");
        return Ok(_serversRep.GetById(id));
    }

    [HttpPost]
    public ActionResult<Server> Add(Server server)
    {
        if (!ip.IsMatch(server.Ip))
        {
            return BadRequest("Ip is incorrect !");
        }
        var receivedServer = _serversRep.GetByIp(server.Ip);
        if (receivedServer != null)
        {
            return BadRequest("This server already exist !");
        }
        return Ok(_serversRep.Add(server));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(uint id)
    {
        var server = _serversRep.GetById(id);
        if (server == null)
        {
            return NotFound("We cannot find this server :(");
        }
        _serversRep.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult Update(Server server, uint id)
    {
        var exsistedServer = _serversRep.GetById(id);
        if (exsistedServer == null)
        {
            return NotFound("Sorry, we can't find this server");
        }
        //var updatedServer = server(server.Ip, server.Online, server.Name, id);
        _serversRep.Delete(exsistedServer.Id);
        _serversRep.AddUnique(server, id);
        return Ok(server);
    }
}
