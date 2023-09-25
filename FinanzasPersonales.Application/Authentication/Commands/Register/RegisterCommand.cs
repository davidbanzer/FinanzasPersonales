using FinanzasPersonales.Application.Authentication.Common;
using MediatR;

namespace FinanzasPersonales.Application.Authentication.Commands.Register;

public record RegisterCommand(
  string FirstName,
  string LastName,
  string Email,
  string Password
) : IRequest<AuthenticationResult>;