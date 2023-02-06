using e07.domain.model;
using Microsoft.EntityFrameworkCore;

namespace e07.infrastructure;
public class DbDataContext : DbContext
{
    public DbSet<Developer> Developers { get; set; }

    public string DbPath { get; }

    public DbDataContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "developers.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}