using System.ComponentModel.DataAnnotations;
using Alfasoft.ContactManager.Constants;

namespace Alfasoft.ContactManager.Contracts.User;

public sealed record UserLoginRequest
{
    [Required(ErrorMessage = UserValidationMessages.UsernameRequired)]
    public required string Username { get; init; }
    
    [Required(ErrorMessage = UserValidationMessages.PasswordRequired)]
    public required string Password { get; init; }
}