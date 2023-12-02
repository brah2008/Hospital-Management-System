using Microsoft.AspNetCore.Authorization;

[Authorize]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    public IActionResult PublicPage()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    public IActionResult AdminPage()
    {
        return View();
    }

    [Authorize(Roles = "Doctor, Nurse")]
    public IActionResult StaffPage()
    {
        return View();
    }
}
