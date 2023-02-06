using e07.domain.model;
using e07.domain.unitofwork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace e07.application.controller;
[ApiController]
[Route("developer")]
public class DeveloperController : ControllerBase
{

    private readonly ILogger<DeveloperController> _logger;

    private readonly IUnitOfWork _unitOfWork;

    public DeveloperController(ILogger<DeveloperController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IEnumerable<Developer> Get()
    {
        _logger.LogInformation(_unitOfWork.ToString());
        return _unitOfWork.DevelopersRepository.GetAll().Result;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Developer developer) // Now we need to validate the model
    {
        _unitOfWork.DevelopersRepository.Add(developer);
        await _unitOfWork.Complete();

        _logger.LogInformation(developer.ToString());
        return Ok();
    }
}