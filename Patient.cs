public class Patient
{
    public int PatientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    // Other properties...
    // Navigation properties
    public ICollection<Appointment> Appointments { get; set; }
}
``
