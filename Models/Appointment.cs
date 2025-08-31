using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace HospitalSysAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please enter your name.")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select a date.")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Please choose a doctor.")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
