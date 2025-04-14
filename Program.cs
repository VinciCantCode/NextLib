using Microsoft.EntityFrameworkCore;
using BestLibraryManagement.Data;
using Microsoft.AspNetCore.Authentication.Google;
using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add DbContext configuration
builder.Services.AddDbContext<BestLibraryManagementDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity to use our BestLibraryManagementDbContext and standard IdentityUser
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<BestLibraryManagementDbContext>();

// Configure external authentication providers
builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });
    //.AddGitHub(githubOptions =>  // Temporarily commented out as GitHub credentials are not configured
    //{
    //    githubOptions.ClientId = builder.Configuration["Authentication:GitHub:ClientId"];
    //    githubOptions.ClientSecret = builder.Configuration["Authentication:GitHub:ClientSecret"];
    //});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Add Razor Pages routes for Identity UI
app.MapRazorPages();

app.Run();
