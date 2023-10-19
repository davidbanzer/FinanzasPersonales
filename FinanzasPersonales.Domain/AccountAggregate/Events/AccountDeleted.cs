using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.AccountAggregate.Events;

public record AccountDeleted(Account Account) : IDomainEvent;