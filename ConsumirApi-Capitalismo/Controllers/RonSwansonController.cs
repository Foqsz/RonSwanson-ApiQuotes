using ConsumirApi_Capitalismo.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirApi_Capitalismo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RonSwansonController : ControllerBase
{
    private readonly IRonSwansonService _RonSwansonService;
    private readonly ILogger _Logger;

    public RonSwansonController(IRonSwansonService ronSwansonService, ILogger<RonSwansonController> logger)
    {
        _RonSwansonService = ronSwansonService;
        _Logger = logger;
    }

    [HttpGet("RandomText")]
    public async Task<ActionResult<string>> GetTextRandom()
    {
        string sendTextToUser = await _RonSwansonService.GetRandomRonSwansonText();

        _Logger.LogInformation("Text regenated sucessfully");
        return sendTextToUser;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<string>> GetTextRandomById(int id)
    { 
        string sendTextId = await _RonSwansonService.GetRonSwansonId(id);

        _Logger.LogInformation("Text regenated sucessfully");
        return sendTextId;  

    }

    [HttpGet("Terms")]
    public async Task<ActionResult<string>> GetTermRandom()
    {
        string sendTermToUser = await _RonSwansonService.GetRonSwansonTerm();

        _Logger.LogInformation("Term generated sucessfully");
        return Ok(sendTermToUser);
    }
}
