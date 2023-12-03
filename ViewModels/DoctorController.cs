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
            // Implement doctor registration logic
            var doctor = new Doctor
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Specialization = model.Specialization
                // Set other properties accordingly
            };

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            // Redirect to the appropriate page, e.g., doctor details or list of doctors
            return RedirectToAction("Details", new { id = doctor.DoctorId });
        }

        return View(model);
    }

    // Add other doctor-related actions (e.g., edit, delete, details) as needed
}
