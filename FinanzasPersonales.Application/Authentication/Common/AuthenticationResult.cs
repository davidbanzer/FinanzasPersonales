using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Authentication.Common;

public record AuthenticationResult(
  User User,
  string Token
);