using Alfasoft.ContactManager.Database;
using Alfasoft.ContactManager.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfasoft.ContactManager.Pages;

[Authorize]
public class DeleteContact(AppDbContext dbContext) : PageModel
{
    public async Task<IActionResult> OnGetAsync(uint id)
    {
        if (id <= 0)
            return RedirectToPage("Default");
        
        var contact = await dbContext.Contacts.FindAsync(id);
        if (contact is null)
            return RedirectToPage("Default");

        contact.Status = ContactStatus.Deleted;
        await dbContext.SaveChangesAsync();
        
        TempData["SuccessMessage"] = "Contact successfully deleted";
        return RedirectToPage("Default");
    }
}