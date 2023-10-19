using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.CategoryAggregate.Events;

public record CategoryDeleted(Category Category) : IDomainEvent;