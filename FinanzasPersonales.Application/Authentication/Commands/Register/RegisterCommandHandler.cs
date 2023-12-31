using FinanzasPersonales.Application.Authentication.Common;
using FinanzasPersonales.Application.Common.Interface.Authentication;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Domain.UserAggregate;
using FinanzasPersonales.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace FinanzasPersonales.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            throw new Exception("El usuario ya existe");
        }
        // Crear el usuario (generar id unico) e insertar en la db
        var hashedPassword = Password.Create(command.Password);
        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            hashedPassword
        );

        _userRepository.Add(user);
        // crear el JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}