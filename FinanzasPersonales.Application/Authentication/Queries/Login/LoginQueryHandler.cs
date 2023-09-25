using FinanzasPersonales.Application.Authentication.Common;
using FinanzasPersonales.Application.Common.Interface.Authentication;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.Entities;
using MediatR;

namespace FinanzasPersonales.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Verificar si el usuario existe
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            throw new Exception("El usuario no existe");
        }
        // Validar si el password es correcto

        if (user.Password != query.Password)
        {
            throw new Exception("Contraseña incorrecta");
        }
        // Crear el JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}