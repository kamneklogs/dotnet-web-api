using e07.domain.model;
using e07.domain.repository;
using Microsoft.EntityFrameworkCore;

namespace e07.domain.unitofwork;

public class UnitOfWork : IUnitOfWork
{

    private readonly DbContext _context;

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    #region Repositories // this is for colapsing the code in the IDE

    private IRepository<Developer> _developersRepository;
    public IRepository<Developer> DevelopersRepository => _developersRepository ??= new Repository<Developer>(_context);

    #endregion

    public async Task<bool> Complete() => await _context.SaveChangesAsync() > 0;

    public void Dispose() => _context.Dispose();
}