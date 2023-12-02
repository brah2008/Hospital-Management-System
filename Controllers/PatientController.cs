[Authorize(Roles = "Admin, Nurse")]
[Route("patients")]
public class PatientController : Controller
{
    private readonly PatientService _patientService;

    public PatientController(PatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var patients = _patientService.GetAllPatients();
        return View(patients);
    }

    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        var patient = _patientService.GetPatientById(id);
        if (patient == null)
        {
            return NotFound();
        }
        return View(patient);
    }

    [HttpGet("{id}/appointments")]
    public IActionResult Appointments(int id)
    {
        var patient = _context.Patients.Include(p => p.Appointments).FirstOrDefault(p => p.PatientId == id);
        if (patient == null)
        {
            return NotFound();
        }

        return View(patient);
    }
}
