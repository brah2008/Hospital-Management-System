[Authorize(Roles = "Admin, Doctor, Nurse")]
[Route("appointments")]
public class AppointmentController : Controller
{
    private readonly ApplicationDbContext _context;

    public AppointmentController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        // Implement logic to populate dropdowns with patient and doctor information
        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AppointmentViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Implement appointment creation logic, and redirect to appropriate page
        }

        return View(model);
    }

    // Add other appointment-related actions (e.g., edit, delete) as needed
}
