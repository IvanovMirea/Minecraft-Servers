using Microsoft.AspNetCore.Mvc;
using MinecraftServers.Repositories;
using MinecraftServers.Models;
using System.Text.RegularExpressions;
using MinecraftServers.Dto;

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
    public ActionResult<Server[]> GetAll()
    {
        return Ok(_serversRep.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Server> GetById(int id)
    {
        var serverById = _serversRep.GetById(id);
        if (serverById == null)
            return NotFound("We can't find this server");
        return Ok(serverById);
    }

    [HttpPost]
    public ActionResult<Server> Add(ServerDto server)
    {
        if (!ip.IsMatch(server.Ip))
        {
            return BadRequest("Ip is incorrect !");
        }
        var receivedServer = _serversRep.GetByIp(server.Ip);
        if (receivedServer != null)
        {
            return BadRequest("This server is already exist !");
        }
        var updatedServer = new Server(server.Ip, 0, server.Name, 0);
        return Ok(_serversRep.Add(updatedServer));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var servToDelete = _serversRep.Delete(id);
        if (servToDelete == false) 
        { 
            return NotFound("Sorry, we can't find this server");
        }
        return Ok("Server are successfully deleted!");
    }

    [HttpPut("{id}")]
    public ActionResult<Server> Update(ServerDto server, int id)
    {
        var serv = _serversRep.Update(server,id);
        if (serv == null)
        {
            return NotFound("Sorry, we can't find this server :(");
        }
        return Ok(serv);
    }
}
