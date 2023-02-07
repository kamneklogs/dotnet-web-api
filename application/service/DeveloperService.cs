using e07.domain.model;
using e07.domain.unitofwork;
using e07.util.extensions;
using Microsoft.Extensions.Logging;

namespace e07.application.service;

public class DeveloperService : IDeveloperService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeveloperService> _logger;

    public DeveloperService(IUnitOfWork unitOfWork, ILogger<DeveloperService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<IEnumerable<Developer>> GetAllAsync()
    {
        return await _unitOfWork.DevelopersRepository.GetAll();
    }

    public async Task<Developer> FindByEmailAsync(string email)
    {
        return await _unitOfWork.DevelopersRepository.Find(d => d.Email == email);
    }

    public async Task<Developer> CreateAsync(Developer developer)
    {
        _unitOfWork.DevelopersRepository.Add(developer);
        await _unitOfWork.Complete();
        return developer;
    }

    public async Task<IEnumerable<Developer>> SearchByCriteriaAsync(string name, int? developerType, int? age, int? workedHours)
    {
        var developers = await _unitOfWork.DevelopersRepository.GetAll();
        if (!string.IsNullOrEmpty(name))
        {
            developers = developers.Where(d => d.FullName.ContainsCaseInsensitive(name));
        }
        if (developerType.HasValue)
        {
            developers = developers.Where(d => d.DeveloperType == (DeveloperType)developerType);
        }

        if (age.HasValue)
        {
            developers = developers.Where(d => d.Age == age);
        }

        if (workedHours.HasValue)
        {
            developers = developers.Where(d => d.WorkedHours == workedHours);
        }

        return developers;
    }

    public async Task DeleteAsync(string email)
    {
        Developer developer = await _unitOfWork.DevelopersRepository.Find(d => d.Email == email);
        _unitOfWork.DevelopersRepository.Remove(developer);
        await _unitOfWork.Complete();
    }

    public async Task<Developer> UpdateAsync(Developer developer)
    {
        _unitOfWork.DevelopersRepository.Update(developer);
        await _unitOfWork.Complete();
        return developer;
    }
}