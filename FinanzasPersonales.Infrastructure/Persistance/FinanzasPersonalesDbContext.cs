using FinanzasPersonales.Domain.Account;
using FinanzasPersonales.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace FinanzasPersonales.Infrastructure.Persistance;

public class FinanzasPersonalesDbContext : DbContext
{
    public FinanzasPersonalesDbContext(DbContextOptions<FinanzasPersonalesDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanzasPersonalesDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}