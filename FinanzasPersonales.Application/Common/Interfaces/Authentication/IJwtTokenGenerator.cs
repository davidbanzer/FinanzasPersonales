

using FinanzasPersonales.Domain.UserAggregate;

namespace FinanzasPersonales.Application.Common.Interface.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}