using FinanzasPersonales.Domain.TransferAggregate;

namespace FinanzasPersonales.Application.Transfers.Common;

public record TransferResult(
    Transfer Transfer
);