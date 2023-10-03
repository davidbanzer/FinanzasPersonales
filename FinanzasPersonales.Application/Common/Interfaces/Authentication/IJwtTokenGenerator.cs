
using FinanzasPersonales.Domain.User;

namespace FinanzasPersonales.Application.Common.Interface.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}