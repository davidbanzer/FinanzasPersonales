using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.User;

namespace FinanzasPersonales.Infrastructure.Persistance;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    public User? GetUserById(Guid id)
    {
        return _users.SingleOrDefault(u => u.Id.Value == id);
    }
}