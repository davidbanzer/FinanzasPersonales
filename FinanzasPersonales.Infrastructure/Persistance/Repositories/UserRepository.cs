using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.User;

namespace FinanzasPersonales.Infrastructure.Persistance;

public class UserRepository : IUserRepository
{
    private readonly FinanzasPersonalesDbContext _dbContext;

    public UserRepository(FinanzasPersonalesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.SingleOrDefault(u => u.Email == email);
    }

    public User? GetUserById(Guid id)
    {
        return _dbContext.Users.SingleOrDefault(u => u.Id.Value == id);
    }
}