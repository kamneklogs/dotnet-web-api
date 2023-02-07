using AutoMapper;
using e07.application.dto;
using e07.application.service;
using e07.domain.model;
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

    private readonly IMapper _mapper;

    private readonly IValidator<DeveloperModificationDTO> _validator;

    private readonly IDeveloperService _developerService;
    public DeveloperController(ILogger<DeveloperController> logger, IMapper mapper, IValidator<DeveloperModificationDTO> validator, IDeveloperService developerService)
    {
        _logger = logger;
        _mapper = mapper;
        _validator = validator;
        _developerService = developerService;
    }

    [HttpGet]
    public IEnumerable<Developer> Get()
    {
        return _developerService.GetAllAsync().Result;
    }

    [HttpGet("{email}")]
    public Developer Get(string email)
    {
        return _developerService.FindByEmailAsync(email).Result;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DeveloperModificationDTO developerDTO) // Now we need to validate the model
    {
        var validationResult = _validator.Validate(developerDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        Developer developer = _mapper.Map<Developer>(developerDTO);

        await _developerService.CreateAsync(developer);

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
        return _developerService.SearchByCriteriaAsync(name, developerType, age, workedHours).Result;
    }

    [HttpDelete("{email}")]
    public async Task<IActionResult> Delete(string email)
    {
        var developer = await _developerService.FindByEmailAsync(email);

        if (developer == null)
        {
            return NotFound();
        }

        await _developerService.DeleteAsync(email);

        return NoContent();
    }

    [HttpPut("{email}")]
    public async Task<IActionResult> Put(string email, [FromBody] DeveloperModificationDTO developerDTO)
    {
        var validationResult = _validator.Validate(developerDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var developer = _developerService.FindByEmailAsync(email).Result;

        if (developer == null)
        {
            return NotFound();
        }

        developer = _mapper.Map(developerDTO, developer);

        await _developerService.UpdateAsync(developer);

        return NoContent();
    }
}