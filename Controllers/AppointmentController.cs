[Route("appointments")]
public class AppointmentController : Controller
{
    private readonly AppointmentService _appointmentService;

    private readonly ApplicationDbContext _context;

    public AppointmentController(AppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        //var appointments = _appointmentService.GetAllAppointments();
        //return View(appointments);

        var appointments = _context.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToList();
        return View(appointments);
    }

    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        var appointment = _appointmentService.GetAppointmentById(id);
        if (appointment == null)
        {
            return NotFound();
        }
        return View(appointment);
    }

    // Other CRUD actions...
}
