namespace Alfasoft.ContactManager.Extensions;

public static class AppAuthenticationPolicyExtensions
{
    public static void AddAuthenticationPolicies(this IServiceCollection services)
    {
        services.AddAuthentication().AddCookie(options =>
        {
            options.LoginPath = "/login";
            options.LogoutPath = "/logout";
            options.AccessDeniedPath = "/login";
            options.Cookie.Name = "Alfasoft.ContactManager.AuthCookie";
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.Lax;
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            options.SlidingExpiration = true;
        });
    }
}