using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace e07.application.controller;
[ApiController]
[Route("developer")]
public class DeveloperController : ControllerBase
{

    private readonly ILogger<DeveloperController> _logger;

    public DeveloperController(ILogger<DeveloperController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        yield return "list of developers";
    }
}