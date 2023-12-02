[Route("doctors")]
public class DoctorController : Controller
{
    private readonly ApplicationDbContext _context;
    public DoctorController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var doctors = _context.Doctors.ToList();
        return View(doctors);
    }
    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        var doctor = _context.Doctors.FirstOrDefault(d => d.DoctorId == id);
        if (doctor == null)
        {
            return NotFound();
        }
        return View(doctor);
    }
    // Other CRUD actions...
}
