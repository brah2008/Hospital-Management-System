public class Appointment
{
    public int AppointmentId { get; set; }
    public DateTime AppointmentDate { get; set; }
    // Other properties...
    
    // Foreign keys
    public int PatientId { get; set; }
    public int DoctorId { get; set; }

    // Navigation properties
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}
