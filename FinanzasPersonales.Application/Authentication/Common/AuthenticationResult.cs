

using FinanzasPersonales.Domain.UserAggregate;

namespace FinanzasPersonales.Application.Authentication.Common;

public record AuthenticationResult(
  User User,
  string Token
);