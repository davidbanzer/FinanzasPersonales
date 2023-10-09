
using FinanzasPersonales.Domain.UserAggregate;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;

namespace FinanzasPersonales.Tests;

public class UserTests
{
    [Fact]
    public void CreateUser_ShouldSucceed()
    {
        // Arrange
        var firstName = "John";
        var lastName = "Doe";
        var email = "johndoe@example.com";
        var password = Password.Create("MySecurePassword1");

        // Act
        var user = User.Create(firstName, lastName, email, password);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(firstName, user.FirstName);
        Assert.Equal(lastName, user.LastName);
        Assert.Equal(email, user.Email);
        Assert.Equal(password.Hash, user.Password.Hash);
    }

    [Theory]
    [InlineData("password")]
    [InlineData("weakpassword")]
    [InlineData("shorta23")]
    [InlineData("nopassword1")]
    public void CreateInvalidPassword_ShouldThrowException(string invalidPassword)
    {
        // Arrange & Act
        Action action = () => Password.Create(invalidPassword);

        // Assert
        var exception = Assert.Throws<Exception>(action);
        Assert.Equal("La contraseña debe tener al menos una letra mayúscula", exception.Message);
    }
}