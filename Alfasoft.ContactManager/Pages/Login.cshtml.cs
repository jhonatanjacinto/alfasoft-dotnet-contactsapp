using System.Security.Claims;
using Alfasoft.ContactManager.Contracts.User;
using Alfasoft.ContactManager.Database;
using Alfasoft.ContactManager.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace Alfasoft.ContactManager.Pages;

[ValidateAntiForgeryToken]
public class Login(AppDbContext dbContext) : PageModel
{
    [BindProperty]
    public UserLoginRequest? UserLogin { get; set; }
    
    [FromQuery]
    public string? ReturnUrl { get; set; }

    public IActionResult OnGet() => Page();
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Username == UserLogin!.Username);
        if (existingUser is null || !Verify(UserLogin!.Password, existingUser.PasswordHash))
        {
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page();
        }
        
        await SignInUserAsync(existingUser);
        return (string.IsNullOrEmpty(ReturnUrl) || ReturnUrl.Contains("/delete")) 
            ? RedirectToPage("Default")
            : Redirect(ReturnUrl);
    }
    
    private async Task SignInUserAsync(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username)
        };
        
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(principal);
    }
}