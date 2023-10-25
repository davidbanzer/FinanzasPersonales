using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.TransferAggregate.Events;

public record TransferDeleted(Transfer Transfer) : IDomainEvent;