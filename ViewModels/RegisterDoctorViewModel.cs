using System.ComponentModel.DataAnnotations;

public class RegisterDoctorViewModel
{
    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Specialization")]
    public string Specialization { get; set; }

    // Add other doctor-specific properties if needed
    // For example, contact information, qualifications, etc.
}
