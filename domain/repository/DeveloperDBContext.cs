using e07.domain.model;
using Microsoft.EntityFrameworkCore;

namespace e07.domain.repository;
public class DeveloperDBContext : DbContext
{
    public DbSet<Developer> Developers { get; set; }

    public string DbPath { get; }

    public DeveloperDBContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "developers.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}