using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovementAggregate.ValueObjects;
using FinanzasPersonales.Domain.TransferAggregate;

namespace FinanzasPersonales.Tests;

public class TransferTests
{
    [Fact]
    public void CreateTransfer_ShouldSucceed()
    {
        // Arrange
        var description = "My transfer";
        var amount = Amount.Create(100);
        var originAccountId = AccountId.CreateUnique();
        var destinationAccountId = AccountId.CreateUnique();
        var originMovementId = MovementId.CreateUnique();
        var destinationMovementId = MovementId.CreateUnique();
        var categoryId = CategoryId.CreateUnique();
        var createdDate = DateTime.Now;

        // Act
        var transfer = Transfer.Create(
            description,
            amount,
            originAccountId,
            destinationAccountId,
            originMovementId,
            destinationMovementId,
            categoryId,
            createdDate
        );

        // Assert

        Assert.NotNull(transfer);
        Assert.Equal(description, transfer.Description);
        Assert.Equal(amount, transfer.Amount);
        Assert.Equal(originAccountId, transfer.OriginAccountId);
        Assert.Equal(destinationAccountId, transfer.DestinationAccountId);
        Assert.Equal(originMovementId, transfer.OriginMovementId);
        Assert.Equal(destinationMovementId, transfer.DestinationMovementId);
        Assert.Equal(createdDate, transfer.CreatedDate);

    }
}