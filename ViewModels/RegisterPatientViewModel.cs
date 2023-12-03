[Authorize(Roles = "Admin, Nurse")]
[Route("patients")]
public class PatientController : Controller
{
    private readonly ApplicationDbContext _context;

    public PatientController(ApplicationDbContext context)
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
    public IActionResult Register(RegisterPatientViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Implement patient registration logic
            var patient = new Patient
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth
                // Set other properties accordingly
            };

            _context.Patients.Add(patient);
            _context.SaveChanges();

            // Redirect to the appropriate page, e.g., patient details or list of patients
            return RedirectToAction("Details", new { id = patient.PatientId });
        }

        return View(model);
    }

    // Add other patient-related actions (e.g., edit, delete, details) as needed
}
