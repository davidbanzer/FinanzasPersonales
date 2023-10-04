using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.User.ValueObjects;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;

namespace FinanzasPersonales.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public Password Password { get; }

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        Password password
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
        Password password
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