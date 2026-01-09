using Microsoft.EntityFrameworkCore;
using Phetolo.Math28.Core.Entities;

namespace Phetolo.Math28.Infrastructure.Data;

public class Math28DBContext : DbContext
{
    public DbSet<Puzzle> Puzzles { get; set; }
    public DbSet<User> Users { get; set; }

    public Math28DBContext(DbContextOptions<Math28DBContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=Phetolo.Math28DB;Username=postgres;Password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Math28DBContext).Assembly);

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
                entry.Property("Created").CurrentValue = entry.Property("Modified").CurrentValue = DateTime.UtcNow;

            if (entry.State == EntityState.Modified)
                entry.Property("Modified").CurrentValue = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
