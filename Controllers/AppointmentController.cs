[Route("appointments")]
public class AppointmentController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly PatientService _patientService;
    private readonly DoctorService _doctorService;
    private readonly AppointmentService _appointmentService;

    public AppointmentController(ApplicationDbContext context, PatientService patientService, DoctorService doctorService, AppointmentService appointmentService)
    {
        _context = context;
        _patientService = patientService;
        _doctorService = doctorService;
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

    [HttpGet("create")]
    public IActionResult Create()
    {
        var patients = _patientService.GetAllPatients();
        var doctors = _doctorService.GetAllDoctors();

        ViewBag.Patients = new SelectList(patients, "PatientId", "FullName");
        ViewBag.Doctors = new SelectList(doctors, "DoctorId", "FullName");

        return View();
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Appointment appointment)
    {
        if (ModelState.IsValid)
        {
            _appointmentService.AddAppointment(appointment);
            return RedirectToAction("Index");
        }

        var patients = _patientService.GetAllPatients();
        var doctors = _doctorService.GetAllDoctors();

        ViewBag.Patients = new SelectList(patients, "PatientId", "FullName", appointment.PatientId);
        ViewBag.Doctors = new SelectList(doctors, "DoctorId", "FullName", appointment.DoctorId);

        return View(appointment);
    }

    // Similar actions for Edit, Delete, etc.
}
