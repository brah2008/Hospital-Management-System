using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

public void ConfigureServices(IServiceCollection services)
{
    // Dependency injection configuration
    services.AddControllersWithViews();
    // Database configuration
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    // Other services...

    services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

    // Configure cookie authentication
    services.ConfigureApplicationCookie(options =>
    {
        options.Cookie.Name = "YourAppCookieName";
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.SlidingExpiration = true;
    });

}
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{

    // Middleware configuration
    app.UseDeveloperExceptionPage();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseAuthentication();
    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });
}
