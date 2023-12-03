public class Patient
{
    public int PatientId { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    // Add other properties as needed

    // Navigation properties
    public ICollection<Appointment> Appointments { get; set; }
}
