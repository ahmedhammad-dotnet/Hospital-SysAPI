using HospitalSysAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSysAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IDoctorRepository doctorRepository;

        public HomeController(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var doctors = doctorRepository.GetAll();
            return Ok(doctors);

        }

        [HttpGet("Details")]
        public IActionResult Details(int id) 
        {
            var doctor = doctorRepository.GetOne(expression: e => e.Id == id);
            if (doctor != null) 
            {
                return Ok(doctor);
            }
            return NotFound();
        }


    }
}
