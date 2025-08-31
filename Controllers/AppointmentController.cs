using HospitalSysAPI.Models;
using HospitalSysAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSysAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IDoctorRepository doctorRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository,IDoctorRepository doctorRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.doctorRepository = doctorRepository;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index(string? search = null) 
        {
            var appointments = appointmentRepository.GetAll([e => e.Doctor]);
            if (search != null && search.Length > 0)
            {
                search = search.TrimStart();
                search = search.TrimEnd();
                appointments = appointments.Where(e => e.PatientName.Contains(search) || e.PhoneNumber.Contains(search));
            }
            if (appointments.Any())
            {
                return Ok(appointments.ToList());
            }
            return NotFound();
        }
        [HttpPost("Create")]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid) 
            {
                var appointment1= new Appointment() 
                {
                PatientName = appointment.PatientName,
                PhoneNumber = appointment.PhoneNumber,
                AppointmentDate = appointment.AppointmentDate,
                Doctor = appointment.Doctor,
                DoctorId = appointment.DoctorId,
                Id = appointment.Id
                };
                appointmentRepository.Add(appointment1);
                appointmentRepository.Save();
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("seccess", "add product", cookieOptions);

                return Ok(appointment1);
            }
            return BadRequest("Home");
        }
        [HttpPut("Edit")]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointmentRepository.Edit(appointment);
                appointmentRepository.Save();
                return Ok(appointment);
            }
            return NotFound();
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var appointment = appointmentRepository.GetOne([e => e.Id == id]);
            if (appointment != null) 
            {
                appointmentRepository.Delete(appointment);
                appointmentRepository.Save();
                return Ok();
            }
             return NotFound();
        }
    }
}
