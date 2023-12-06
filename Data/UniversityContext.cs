using Microsoft.EntityFrameworkCore;
namespace ApiUniversity.Models;


public class UniversityContext : DbContext
{
    public DbSet<Course> Course { get; set; } = null!;
    public DbSet<Enrollment> Enrollment { get; set; } = null!;
    public DbSet<Student> Student { get; set; } = null!;
    public string DbPath { get; private set; }


    public UniversityContext()
    {
        // Path to SQLite database file
        DbPath = "EFUniversity.db";
    }


    // The following configures EF to create a SQLite database file locally
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        //options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }
}
