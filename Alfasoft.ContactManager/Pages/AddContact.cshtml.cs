using Alfasoft.ContactManager.Contracts.Contact;
using Alfasoft.ContactManager.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Alfasoft.ContactManager.Pages;

[Authorize]
[ValidateAntiForgeryToken]
public class AddContact(AppDbContext dbContext) : PageModel
{
    [BindProperty]
    public CreateContact? CreateContactData { get; set; }
    
    public IActionResult OnGet() => Page();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || CreateContactData is null)
            return Page();
        
        if (await dbContext.Contacts.AnyAsync(c => c.Email == CreateContactData.Email || c.Phone == CreateContactData.PhoneNumber))
        {
            ModelState.AddModelError(string.Empty, "A contact with the same email or phone number already exists.");
            return Page();
        }
        
        var contact = (Models.Contact)CreateContactData;
        await dbContext.Contacts.AddAsync(contact);
        await dbContext.SaveChangesAsync();
        
        TempData["SuccessMessage"] = "Contact successfully added";
        return RedirectToPage("AddContact");
    }
}