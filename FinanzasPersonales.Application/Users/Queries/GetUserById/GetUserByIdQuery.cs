using FinanzasPersonales.Domain.User;
using MediatR;

namespace FinanzasPersonales.Application.Authentication.Queries.GetUserById;

public record GetUserByIdQuery(
  Guid UserId
) : IRequest<User>;
