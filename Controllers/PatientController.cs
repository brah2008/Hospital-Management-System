[Route("patients")]
public class PatientController : Controller
{
    private readonly ApplicationDbContext _context;
    public PatientController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var patients = _context.Patients.ToList();
        return View(patients);
    }
    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        var patient = _context.Patients.FirstOrDefault(p => p.PatientId == id);
        if (patient == null)
        {
            return NotFound();
        }
        return View(patient);
    }
    // Other CRUD actions...
}
