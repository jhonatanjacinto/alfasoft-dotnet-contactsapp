using Alfasoft.ContactManager.Database;
using Alfasoft.ContactManager.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySqlConnection") ?? throw new InvalidOperationException("Connection string to database not found.");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

app.RunInitialMigrations();
app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();