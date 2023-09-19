using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Common.Interface.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}