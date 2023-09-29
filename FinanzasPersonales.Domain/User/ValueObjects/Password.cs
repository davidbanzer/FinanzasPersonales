using FinanzasPersonales.Domain.Common.Models;

namespace FinanzasPersonales.Domain.User.ValueObjects;

public sealed class Password : ValueObject
    {
        public string Value { get; }

        private Password(string value)
        {
            Value = value;
        }

        public static Password Create(string password)
        {

            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");
            }

            // incluir mayúsculas, minusculas y un número
            if (!password.Any(char.IsUpper))
            {
                throw new ArgumentException("La contraseña debe tener al menos una mayúscula.");
            }

            if (!password.Any(char.IsLower))
            {
                throw new ArgumentException("La contraseña debe tener al menos una minúscula.");
            }

            if (!password.Any(char.IsDigit))
            {
                throw new ArgumentException("La contraseña debe tener al menos un número.");
            }

            return new Password(password);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }