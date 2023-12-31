using FinanzasPersonales.Domain.Common.Models;
using FinanzasPersonales.Domain.UserAggregate.Events;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;

namespace FinanzasPersonales.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public Password Password { get; private set; }

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
        var user = new User(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password
        );

        user.AddDomainEvent(new UserCreated(user));
        return user;
    }

#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618

}