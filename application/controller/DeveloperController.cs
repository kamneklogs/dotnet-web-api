using AutoMapper;
using e07.application.dto;
using e07.domain.model;
using e07.domain.unitofwork;
using e07.util.extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace e07.application.controller;
[ApiController]
[Route("developer")]
public class DeveloperController : ControllerBase
{

    private readonly ILogger<DeveloperController> _logger;

    private readonly IUnitOfWork _unitOfWork; // If is necessary, move this related logic to the service layer

    private readonly IMapper _mapper;

    private readonly IValidator<DeveloperCreationDTO> _validator;

    public DeveloperController(ILogger<DeveloperController> logger, IUnitOfWork unitOfWork, IMapper mapper, IValidator<DeveloperCreationDTO> validator)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
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
    public async Task<IActionResult> Post([FromBody] DeveloperCreationDTO developerDTO) // Now we need to validate the model
    {
        var validationResult = _validator.Validate(developerDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        Developer developer = _mapper.Map<Developer>(developerDTO);

        _unitOfWork.DevelopersRepository.Add(developer);
        await _unitOfWork.Complete();

        return CreatedAtAction(nameof(Get), new { id = developer.Email }, developer);
    }

    // Search a developer by criteria

    [HttpGet("search")]
    public IEnumerable<Developer> Search(
        [FromQuery] string name,
        [FromQuery] int? developerType,
        [FromQuery] int? age,
        [FromQuery] int? workedHours)
    {
        var developers = _unitOfWork.DevelopersRepository.GetAll().Result;

        if (!string.IsNullOrEmpty(name))
        {
            developers = developers.Where(d => d.FullName.ContainsCaseInsensitive(name)); // Extension method
        }

        if (developerType.HasValue)
        {
            developers = developers.Where(d => d.DeveloperType == DeveloperTypeExtensions.FromId(developerType.Value));
        }

        if (age.HasValue)
        {
            developers = developers.Where(d => d.Age == age.Value);
        }

        if (workedHours.HasValue)
        {
            developers = developers.Where(d => d.WorkedHours == workedHours.Value);
        }

        return developers;
    }

    //Delete and update methods are not implemented yet. TODO
}