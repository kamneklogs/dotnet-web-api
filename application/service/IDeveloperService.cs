using e07.domain.model;

namespace e07.application.service;

public interface IDeveloperService
{
    Task<IEnumerable<Developer>> GetAllAsync();
    Task<Developer> FindByEmailAsync(string email);
    Task<Developer> CreateAsync(Developer developer);
    Task<IEnumerable<Developer>> SearchByCriteriaAsync(string name, int? developerType, int? age, int? workedHours);
    Task DeleteAsync(string email);
    Task<Developer> UpdateAsync(Developer developer);
}
