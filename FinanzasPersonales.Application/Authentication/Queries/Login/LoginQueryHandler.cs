using BCrypt.Net;
using FinanzasPersonales.Application.Authentication.Common;
using FinanzasPersonales.Application.Common.Interface.Authentication;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.User;
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
        await Task.CompletedTask;
        // Verificar si el usuario existe
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            throw new Exception("El usuario no existe");
        }
        // Validar si el password es correcto

        // Validar si la contraseña es correcta utilizando BCrypt.Verify
        if (!BCrypt.Net.BCrypt.Verify(query.Password, user.Password.Hash))
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