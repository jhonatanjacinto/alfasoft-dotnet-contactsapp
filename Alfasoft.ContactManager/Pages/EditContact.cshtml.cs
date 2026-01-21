using Alfasoft.ContactManager.Contracts.Contact;
using Alfasoft.ContactManager.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Alfasoft.ContactManager.Pages;

[Authorize]
public class EditContact(AppDbContext dbContext) : PageModel
{
    [BindProperty]
    public UpdateContact? UpdateContactData { get; set; }
    
    public async Task<IActionResult> OnGetAsync(uint id)
    {
        if (id <= 0)
            return RedirectToPage("Default");
        
        var contact = await dbContext.Contacts.FindAsync(id);
        if (contact is null)
            return RedirectToPage("Default");

        UpdateContactData = new UpdateContact
        {
            Id = contact.Id,
            Name = contact.Name,
            Email = contact.Email,
            PhoneNumber = contact.Phone
        };
        
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || UpdateContactData is null)
            return Page();
        
        var contact = await dbContext.Contacts.FindAsync(UpdateContactData.Id);
        if (contact is null)
            return RedirectToPage("Default");

        contact.Name = UpdateContactData.Name;
        contact.Email = UpdateContactData.Email;
        contact.Phone = UpdateContactData.PhoneNumber;
        
        if (await dbContext.Contacts.AnyAsync(c => (c.Email == contact.Email || c.Phone == contact.Phone) && c.Id != contact.Id))
        {
            ModelState.AddModelError(string.Empty, "Another contact with the same email or phone number already exists.");
            return Page();
        }

        await dbContext.SaveChangesAsync();
        
        TempData["SuccessMessage"] = "Contact updated successfully.";
        return RedirectToPage("EditContact", new { id = contact.Id });
    }
}