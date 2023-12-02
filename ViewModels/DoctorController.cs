[Authorize(Roles = "Admin")]
[Route("doctors")]
public class DoctorController : Controller
{
    private readonly ApplicationDbContext _context;

    public DoctorController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("register")]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterDoctorViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Implement doctor registration logic, and redirect to appropriate page
        }

        return View(model);
    }

    // Add other doctor-related actions (e.g., edit, delete) as needed
}
