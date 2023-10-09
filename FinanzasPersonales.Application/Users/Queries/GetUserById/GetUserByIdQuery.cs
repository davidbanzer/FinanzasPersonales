using FinanzasPersonales.Application.Users.Common;
using MediatR;

namespace FinanzasPersonales.Application.Authentication.Queries.GetUserById;

public record GetUserByIdQuery(
  Guid UserId
) : IRequest<UserResult>;
