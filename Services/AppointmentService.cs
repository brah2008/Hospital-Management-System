public class AppointmentService
{
    private readonly ApplicationDbContext _context;
    
    public AppointmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Appointment> GetAllAppointments()
    {
        return _context.Appointments.ToList();
    }

    public Appointment GetAppointmentById(int id)
    {
        return _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
    }

    public void AddAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        _context.SaveChanges();
    }

    public void UpdateAppointment(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
        _context.SaveChanges();
    }

    public void DeleteAppointment(int id)
    {
        var appointment = _context.Appointments.Find(id);
        if (appointment != null)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }
    }
}
