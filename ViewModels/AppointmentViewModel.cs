public class AppointmentViewModel
{
    [Required]
    [Display(Name = "Appointment Date")]
    public DateTime AppointmentDate { get; set; }

    // Add other appointment-specific properties if needed
}
