using AutoMapper;
using e07.application.dto;
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

    private readonly IMapper _mapper;

    public DeveloperController(ILogger<DeveloperController> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Developer> Get()
    {
        return _unitOfWork.DevelopersRepository.GetAll().Result;
    }

    [HttpGet("{id}")]
    public Developer Get(string id)
    {
        return _unitOfWork.DevelopersRepository.Find(d => d.Email == id).Result;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DeveloperDTO developerDTO) // Now we need to validate the model
    {
        Developer developer = _mapper.Map<Developer>(developerDTO);

        _unitOfWork.DevelopersRepository.Add(developer);
        await _unitOfWork.Complete();

        return CreatedAtAction(nameof(Get), new { id = developer.Email }, developer);
    }
}