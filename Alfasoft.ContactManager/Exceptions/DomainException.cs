namespace Alfasoft.ContactManager.Exceptions;

public sealed class DomainException(string? message) : Exception(message)
{
    public static void ThrowIf(bool condition, string? message)
    {
        if (condition)
            throw new DomainException(message);
    }  
}