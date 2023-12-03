public class DoctorService
{
    private readonly ApplicationDbContext _context;
    
    public DoctorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Doctor> GetAllDoctors()
    {
        return _context.Doctors.ToList();
    }

    public Doctor GetDoctorById(int id)
    {
        return _context.Doctors.FirstOrDefault(d => d.DoctorId == id);
    }

    public void AddDoctor(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
    }

    public void UpdateDoctor(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        _context.SaveChanges();
    }

    public void DeleteDoctor(int id)
    {
        var doctor = _context.Doctors.Find(id);
        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}
