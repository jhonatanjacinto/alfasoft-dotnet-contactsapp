using System.ComponentModel.DataAnnotations;
using Alfasoft.ContactManager.Enums;

namespace Alfasoft.ContactManager.Models;

public sealed class Contact
{
    [Key]
    public uint Id { get; set; }
    
    [MaxLength(250)]
    public required string Name { get; set; }
    
    [MaxLength(150)]
    public required string Email { get; set; }
    
    [MaxLength(9)]
    public required string Phone { get; set; }
    
    [MaxLength(20)]
    [EnumDataType(typeof(ContactStatus))]
    public ContactStatus Status { get; set; } = ContactStatus.Active;
}