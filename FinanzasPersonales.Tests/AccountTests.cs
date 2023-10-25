using FinanzasPersonales.Domain.AccountAggregate;
using FinanzasPersonales.Domain.Common.ValueObjects;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;

namespace FinanzasPersonales.Tests;

public class AccountTest
{
    [Fact]
    public void CreateAccount_ShouldSucceed()
    {
        // Arrange
        var name = "My account";
        var description = "My account description";
        var initialBalance = Amount.Create(100);
        var userId = UserId.CreateUnique();

        var account = Account.Create(name, description, initialBalance, userId);

        Assert.NotNull(account);
        Assert.Equal(name, account.Name);
        Assert.Equal(description, account.Description);
        Assert.Equal(initialBalance, account.InitialBalance);
        Assert.Equal(userId, account.UserId);
    }

    [Fact]
    public void UpdateAccount_ShouldSucceed()
    {
        // Arrange
        var name = "My account";
        var description = "My account description";
        var initialBalance = Amount.Create(100);
        var userId = UserId.CreateUnique();

        var account = Account.Create(name, description, initialBalance, userId);

        var newName = "My account updated";
        var newDescription = "My account description updated";
        var newInitialBalance = Amount.Create(200);

        // Act
        account.Update(newName, newDescription, newInitialBalance);

        // Assert
        Assert.Equal(newName, account.Name);
        Assert.Equal(newDescription, account.Description);
        Assert.Equal(newInitialBalance, account.InitialBalance);
    }

}