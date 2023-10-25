using FinanzasPersonales.Domain.CategoryAggregate;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;

namespace FinanzasPersonales.Tests;

public class CategoryTests
{
    [Fact]
    public void CreateCategory_ShouldSucceed()
    {
        // Arrange
        var name = "My category";
        var description = "My category description";
        var userId = UserId.CreateUnique();

        var category = Category.Create(name, description, userId);

        Assert.NotNull(category);
        Assert.Equal(name, category.Name);
        Assert.Equal(description, category.Description);
        Assert.Equal(userId, category.UserId);
    }
}