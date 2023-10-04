using FinanzasPersonales.Domain.Account.ValueObjects;
using FinanzasPersonales.Domain.Category.ValueObjects;
using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.User.ValueObjects;

namespace FinanzasPersonales.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password
    ) : base(userId)
    {
        Id = userId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password
    )
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password
        );
    }

}