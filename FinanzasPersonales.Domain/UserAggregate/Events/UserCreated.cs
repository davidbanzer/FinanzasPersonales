using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.UserAggregate.Events;

public record UserCreated(User User) : IDomainEvent;