
using FinanzasPersonales.Domain.User;

namespace FinanzasPersonales.Application.Common.Interfaces.Persistance;

public interface IUserRepository
{
  User? GetUserByEmail(string email);
  User? GetUserById(Guid id);
  void Add(User user);
}