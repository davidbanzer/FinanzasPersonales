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
}