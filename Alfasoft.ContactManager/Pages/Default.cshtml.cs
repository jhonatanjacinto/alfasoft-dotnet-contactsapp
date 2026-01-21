using Alfasoft.ContactManager.Database;
using Alfasoft.ContactManager.Enums;
using Alfasoft.ContactManager.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Alfasoft.ContactManager.Pages;

public class Default(AppDbContext dbContext) : PageModel
{
    public List<Contact> Contacts { get; set; } = [];
    
    public async Task OnGetAsync()
    {
        Contacts = await dbContext.Contacts.Where(c => c.Status != ContactStatus.Deleted).ToListAsync();
    }
}