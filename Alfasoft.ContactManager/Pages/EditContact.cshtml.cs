using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfasoft.ContactManager.Pages;

[Authorize]
public class EditContact : PageModel
{
    public void OnGet()
    {
        
    }
}