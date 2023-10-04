using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.UserAggregate.ValueObjects;

public sealed class Password : ValueObject
{
        public string Hash { get; }

        private Password(string hash)
        {
            Hash = hash;
        }

        public static Password Create(string plainTextPassword)
        {
            // Validar que sea una contraseña segura
            if (plainTextPassword.Length < 8)
            {
                throw new Exception("La contraseña debe tener al menos 8 caracteres");
            }

            if (!plainTextPassword.Any(char.IsUpper))
            {
                throw new Exception("La contraseña debe tener al menos una letra mayúscula");
            }

            // Genera un hash seguro usando BCrypt
            string hash = BCrypt.Net.BCrypt.HashPassword(plainTextPassword);

            return new Password(hash);
        }

        public bool VerifyPassword(string plainTextPassword)
        {
            // Verifica si la contraseña ingresada coincide con el hash almacenado
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, Hash);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Hash;
        }
}