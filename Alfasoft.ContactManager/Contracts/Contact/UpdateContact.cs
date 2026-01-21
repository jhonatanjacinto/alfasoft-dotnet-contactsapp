using System.ComponentModel.DataAnnotations;
using Alfasoft.ContactManager.Constants;

namespace Alfasoft.ContactManager.Contracts.Contact;

public sealed record UpdateContact
{
    [Required] public uint Id { get; init; }

    [Required(ErrorMessage = ContactValidationMessages.NameRequired)]
    [MinLength(5, ErrorMessage = ContactValidationMessages.NameMinLength)]
    public required string Name { get; init; }

    [Required(ErrorMessage = ContactValidationMessages.EmailRequired)]
    [EmailAddress(ErrorMessage = ContactValidationMessages.EmailInvalid)]
    public required string Email { get; init; }

    [Required(ErrorMessage = ContactValidationMessages.PhoneRequired)]
    [Phone(ErrorMessage = ContactValidationMessages.PhoneInvalid)]
    [Length(9, 9, ErrorMessage = ContactValidationMessages.PhoneLength)]
    public required string PhoneNumber { get; init; }

    public static explicit operator Models.Contact(UpdateContact contact) => new()
    {
        Id = contact.Id,
        Name = contact.Name,
        Email = contact.Email,
        Phone = contact.PhoneNumber
    };
}