using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Services.Authentication
{
  public record AuthenticationResult(
    User User,
    string Token
  );
}