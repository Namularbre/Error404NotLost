using Error404NotLost_BLL.Services;
using Error404NotLost_DAL;
using Error404NotLost_DAL.Roles;
using Error404NotLost_WEBASP.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

#region Admin User Creation

static async Task CreateAdminUser(IServiceProvider serviceProvider)
{
    string adminSettingsEmailEnvironnementVariable = "AdminSettingsEmail";
    string adminSettingsPasswordEnvironnementVariable = "AdminSettingsPassword";

    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    
    string adminEmail = Environment.GetEnvironmentVariable(adminSettingsEmailEnvironnementVariable) ?? throw new ArgumentException($"Missing {adminSettingsEmailEnvironnementVariable} environnement variable");
    string adminPassword = Environment.GetEnvironmentVariable(adminSettingsPasswordEnvironnementVariable) ?? throw new ArgumentException($"Missing {adminSettingsPasswordEnvironnementVariable} environnement variable");
    string adminRole = nameof(ERoles.Admin);

    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            await userManager.AddToRoleAsync(adminUser, adminRole);
        }
        else
        {
            throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}

#endregion

#region Role Creation

static async Task CreatesRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roleNames = { nameof(ERoles.Admin), nameof(ERoles.Moderator) };
    IdentityResult roleResult;
    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}

#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Register the DbContext with the connection string
builder.Services.AddDbContext<Error404NotLostDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Define the IdentityUser and configure Identity options
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Error404NotLostDbContext>();

builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Custom service registration
builder.Services.AddScoped<SchoolClassService>();
builder.Services.AddScoped<SchoolSubjectService>();

var app = builder.Build();

// Create roles & admin user at startup
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
await CreatesRoles(services);
await CreateAdminUser(services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Custom middleware to log requests and responses
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
