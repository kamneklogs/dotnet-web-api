using e07.domain.model;
using e07.domain.repository;

namespace e07.domain.unitofwork;

public interface IUnitOfWork : IDisposable
{
    IRepository<Developer> DevelopersRepository { get; }
    Task<bool> Complete();
}