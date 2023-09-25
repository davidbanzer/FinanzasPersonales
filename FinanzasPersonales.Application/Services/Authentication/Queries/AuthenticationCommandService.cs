using FinanzasPersonales.Application.Common.Interface.Authentication;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Verificar si el usuario ya existe
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("El usuario ya existe");
        }
        // Crear el usuario (generar id unico) e insertar en la db
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);
        // crear el JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Verificar si el usuario existe
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("El usuario no existe");
        }
        // Validar si el password es correcto

        if (user.Password != password)
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