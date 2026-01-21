using System.ComponentModel.DataAnnotations;

namespace Alfasoft.ContactManager.Models;

public sealed class User
{
    [Key]
    public uint Id { get; set; }
    
    [MaxLength(250)]
    public required string Name { get; set; }
    
    [MaxLength(150)]
    public required string Username { get; set; }
    
    [MaxLength(512)]
    public required string PasswordHash { get; set; }
}