public class Doctor
{
    public int DoctorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    // Other properties...
    // Navigation properties
    public ICollection<Appointment> Appointments { get; set; }
}
