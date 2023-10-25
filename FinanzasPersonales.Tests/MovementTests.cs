using FinanzasPersonales.Domain.AccountAggregate.ValueObjects;
using FinanzasPersonales.Domain.CategoryAggregate.ValueObjects;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.MovementAggregate;

namespace FinanzasPersonales.Tests;

public class MovementTests
{
    [Fact]
    public void CreateMovement_ShouldSucceed()
    {
        // Arrange
        var description = "My movement";
        var amount = Amount.Create(100);
        var type = "I";
        var accountId = AccountId.CreateUnique();
        var categoryId = CategoryId.CreateUnique();
        var createdDate = DateTime.Now;

        // Act
        var movement = Movement.Create(description, amount,type, accountId, categoryId, createdDate);

        // Assert
        Assert.NotNull(movement);
        Assert.Equal(description, movement.Description);
        Assert.Equal(amount, movement.Amount);
        Assert.Equal(type, movement.Type);
        Assert.Equal(accountId, movement.AccountId);
        Assert.Equal(categoryId, movement.CategoryId);
        Assert.Equal(createdDate, movement.CreatedDate);
    }

    [Fact]
    public void createInvalidAmount_ShouldThrowException()
    {
        
        Action action = () => Amount.Create(-100);
        
        var exception = Assert.Throws<Exception>(action);

        Assert.Equal("El monto debe ser mayor a 0", exception.Message);
    }

}