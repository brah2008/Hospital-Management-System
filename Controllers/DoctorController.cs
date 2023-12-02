[Authorize(Roles = "Admin, Doctor")]
[Route("doctors")]
public class DoctorController : Controller
{
    private readonly DoctorService _doctorService;

    public DoctorController(DoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var doctors = _doctorService.GetAllDoctors();
        return View(doctors);
    }

    //[HttpGet("{id}")]
    //public IActionResult Details(int id)
    //{
    //   var doctor = _doctorService.GetDoctorById(id);
    //   if (doctor == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(doctor);
    //}

    [HttpGet("{id}/appointments")]
    public IActionResult Appointments(int id)
    {
        var doctor = _context.Doctors.Include(d => d.Appointments).FirstOrDefault(d => d.DoctorId == id);
        if (doctor == null)
        {
            return NotFound();
        }

        return View(doctor);
    }

    // Other CRUD actions...
}
