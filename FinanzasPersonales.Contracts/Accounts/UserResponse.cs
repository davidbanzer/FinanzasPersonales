namespace FinanzasPersonales.Contracts.Authentication;

public record UserResponse(
  Guid Id,
  string FirstName,
  string LastName,
  string Email
);