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
        // For example, you can use ViewBag or ViewData to pass data to the view
        ViewBag.Patients = _context.Patients.ToList();
        ViewBag.Doctors = _context.Doctors.ToList();

        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AppointmentViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Implement appointment creation logic
            var appointment = new Appointment
            {
                AppointmentDate = model.AppointmentDate,
                PatientId = model.PatientId,
                DoctorId = model.DoctorId,
                // Additional properties assignment
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            // Redirect to the appropriate page (e.g., details page)
            return RedirectToAction("Details", new { id = appointment.AppointmentId });
        }

        // If ModelState is not valid, repopulate dropdowns and return to the create view
        ViewBag.Patients = _context.Patients.ToList();
        ViewBag.Doctors = _context.Doctors.ToList();
        return View(model);
    }

    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        var appointment = _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .FirstOrDefault(a => a.AppointmentId == id);

        if (appointment == null)
        {
            return NotFound();
        }

        return View(appointment);
    }

    // Add other appointment-related actions (e.g., edit, delete) as needed
}
