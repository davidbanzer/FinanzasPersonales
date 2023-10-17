using FinanzasPersonales.Domain.AccountAggregate;
using FinanzasPersonales.Domain.CategoryAggregate;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.MovementAggregate;
using FinanzasPersonales.Domain.TransferAggregate;
using FinanzasPersonales.Domain.UserAggregate;
using FinanzasPersonales.Infrastructure.Persistance.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace FinanzasPersonales.Infrastructure.Persistance;

public class FinanzasPersonalesDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
    public FinanzasPersonalesDbContext(DbContextOptions<FinanzasPersonalesDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Movement> Movements { get; set; } = null!;
    public DbSet<Transfer> Transfers { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(FinanzasPersonalesDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}