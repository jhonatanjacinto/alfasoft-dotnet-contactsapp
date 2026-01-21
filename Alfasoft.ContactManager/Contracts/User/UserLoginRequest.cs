using System.ComponentModel.DataAnnotations;

namespace Alfasoft.ContactManager.Contracts.User;

public sealed record UserLoginRequest
{
    [Required(ErrorMessage = "Username is required.")]
    public required string Username { get; init; }
    
    [Required(ErrorMessage = "Password is required.")]
    public required string Password { get; init; }
}