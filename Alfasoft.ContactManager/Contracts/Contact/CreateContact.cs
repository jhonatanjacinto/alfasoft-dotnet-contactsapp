using System.ComponentModel.DataAnnotations;

namespace Alfasoft.ContactManager.Contracts.Contact;

public sealed record CreateContact
{
    [Required(ErrorMessage = "The name is required")]
    [MinLength(5, ErrorMessage =  "The name must be at least 5 characters long")]
    public required string Name { get; init; }
    
    [Required(ErrorMessage = "The email is required")]
    [EmailAddress(ErrorMessage = "The email is not valid")]
    public required string Email { get; init; }
    
    [Phone(ErrorMessage = "The phone number is not valid")]
    [Length(9, 9, ErrorMessage = "The phone number must be 9 digits long")]
    public required string PhoneNumber { get; init; }

    public static explicit operator Models.Contact(CreateContact contact) => new()
    {
        Name = contact.Name,
        Email = contact.Email,
        Phone = contact.PhoneNumber
    };
}