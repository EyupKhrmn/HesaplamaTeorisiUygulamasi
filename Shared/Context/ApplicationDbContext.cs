using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Shared.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany<AıResponse>(_=>_.Responses)
            .WithOne(_=>_.User);
    }
}