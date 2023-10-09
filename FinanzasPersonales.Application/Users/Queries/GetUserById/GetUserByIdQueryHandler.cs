using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Application.Users.Common;
using MediatR;

namespace FinanzasPersonales.Application.Authentication.Queries.GetUserById;


public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResult>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Obtener usuario
        var user = _userRepository.GetUserById(request.UserId);

        if (user is null)
        {
            throw new Exception("El usuario no existe");
        }
        // Retornar usuario
        return new UserResult(user);
    }
}