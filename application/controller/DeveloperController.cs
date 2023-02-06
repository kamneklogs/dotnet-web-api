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

    public DeveloperController(ILogger<DeveloperController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public  IEnumerable<Developer> Get()
    {
        return _unitOfWork.DevelopersRepository.GetAll().Result;
    }
}