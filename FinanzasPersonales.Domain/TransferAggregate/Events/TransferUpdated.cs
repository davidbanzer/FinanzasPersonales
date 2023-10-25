using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.TransferAggregate.Events;

public record TransferUpdated(Transfer Transfer, CategoryId CategoryId) : IDomainEvent;