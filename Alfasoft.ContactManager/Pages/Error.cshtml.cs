using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfasoft.ContactManager.Pages;

public class Error : PageModel
{
    [FromQuery(Name = "code")]
    public int? ErrorCode { get; set; }
    
    public void OnGet()
    {
        
    }
}