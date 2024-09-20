namespace Contacts;

public class Contact
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MobileNumber { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string[]? Address { get; set; } // Street, city
}