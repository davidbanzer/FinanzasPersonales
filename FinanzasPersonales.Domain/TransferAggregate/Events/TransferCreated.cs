using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.TransferAggregate.Events;

public record TransferCreated(Transfer Transfer) : IDomainEvent;