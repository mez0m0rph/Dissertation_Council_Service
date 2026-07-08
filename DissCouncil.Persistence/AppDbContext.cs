using Microsoft.EntityFrameworkCore;
using DissCouncil.Domain.Entities;

namespace DissCouncil.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Dissertation> Dissertations { get; set; }
    public DbSet<Applicant> Applicants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dissertation>()
            .Property(d => d.Type)
            .HasConversion<string>();
        
        modelBuilder.Entity<Dissertation>()
            .Property(d => d.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Applicant>()
            .Property(x => x.Degree)
            .HasConversion<string>();
    }
}