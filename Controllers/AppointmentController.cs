[Route("appointments")]
public class AppointmentController : Controller
{
    private readonly AppointmentService _appointmentService;

    public AppointmentController(AppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var appointments = _appointmentService.GetAllAppointments();
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
