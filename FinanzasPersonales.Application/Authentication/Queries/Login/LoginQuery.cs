using FinanzasPersonales.Application.Authentication.Common;
using MediatR;

namespace FinanzasPersonales.Application.Authentication.Queries.Login;

public record LoginQuery(
  string Email,
  string Password
) : IRequest<AuthenticationResult>;