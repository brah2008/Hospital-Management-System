public void ConfigureServices(IServiceCollection services)
{
    // Dependency injection configuration
    services.AddControllersWithViews();
    // Database configuration
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    // Other services...
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
