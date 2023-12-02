[Authorize(Roles = "Admin, Nurse")]
[Route("patients")]
public class PatientController : Controller
{
    private readonly ApplicationDbContext _context;

    public PatientController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Existing actions...

    [HttpGet("{id}/appointments/create")]
    public IActionResult CreateAppointment(int id)
    {
        var patient = _context.Patients.Find(id);
        if (patient == null)
        {
            return NotFound();
        }

        var appointment = new Appointment
        {
            PatientId = patient.PatientId,
            // Set other default values for the appointment
        };

        return View(appointment);
    }

    [HttpPost("{id}/appointments/create")]
    [ValidateAntiForgeryToken]
    public IActionResult CreateAppointment(int id, [Bind("AppointmentDate")] Appointment appointment)
    {
        var patient = _context.Patients.Find(id);
        if (patient == null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            appointment.PatientId = patient.PatientId;
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Appointments), new { id = patient.PatientId });
        }

        return View(appointment);
    }

    [HttpGet("appointments/{appointmentId}/edit")]
    public IActionResult EditAppointment(int appointmentId)
    {
        var appointment = _context.Appointments.Find(appointmentId);
        if (appointment == null)
        {
            return NotFound();
        }

        return View(appointment);
    }

    [HttpPost("appointments/{appointmentId}/edit")]
    [ValidateAntiForgeryToken]
    public IActionResult EditAppointment(int appointmentId, [Bind("AppointmentDate")] Appointment appointment)
    {
        var existingAppointment = _context.Appointments.Find(appointmentId);
        if (existingAppointment == null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            existingAppointment.AppointmentDate = appointment.AppointmentDate;
            // Update other properties if needed
            _context.SaveChanges();
            return RedirectToAction(nameof(Appointments), new { id = existingAppointment.PatientId });
        }

        return View(appointment);
    }

    [HttpPost("appointments/{appointmentId}/delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteAppointment(int appointmentId)
    {
        var appointment = _context.Appointments.Find(appointmentId);
        if (appointment == null)
        {
            return NotFound();
        }

        _context.Appointments.Remove(appointment);
        _context.SaveChanges();
        return RedirectToAction(nameof(Appointments), new { id = appointment.PatientId });
    }
}
