using System;
using System.ComponentModel.DataAnnotations;

public class AppointmentViewModel
{
    [Required]
    [Display(Name = "Appointment Date")]
    public DateTime AppointmentDate { get; set; }

    [Required]
    [Display(Name = "Patient")]
    public int PatientId { get; set; }

    [Required]
    [Display(Name = "Doctor")]
    public int DoctorId { get; set; }

    // Add other appointment-specific properties if needed
    // For example, additional notes, reason for appointment, etc.
}
