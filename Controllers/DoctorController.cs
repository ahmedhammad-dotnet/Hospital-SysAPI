using HospitalSysAPI.Models;
using HospitalSysAPI.Repository.IRepository;
using HospitalSysAPI.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSysAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = SD.adminRole)]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index(int page = 1, string? search = null)
        {
            if (page <= 0)
                page = 1;
            IQueryable<Doctor> cts = doctorRepository.GetAll();
            if (search != null && search.Length > 0)
            {
                search = search.TrimStart();
                search = search.TrimEnd();
                cts = cts.Where(e => e.Name.Contains(search));
            }
            cts = cts.Skip((page - 1) * 5).Take(5);
            if (cts.Any())
                return Ok(cts.ToList());

            return NotFound();
        }
        [HttpPost("Create")]
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctorRepository.Add(doctor);
                doctorRepository.Save();
                return Created($"{Request.Scheme}://{Request.Host}/api/Category/Details?categoryId={doctor.Id}", doctor);
            }
            return BadRequest(doctor);
        }
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {

            var cts = doctorRepository.GetOne([], e => e.Id == id);
            if (cts != null)
            {
                return Ok(cts);
            }
            return NotFound();
        }
        [HttpPut("Edit")]
        public IActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctorRepository.Edit(doctor);
                doctorRepository.Save();
                return Created($"{Request.Scheme}://{Request.Host}/api/Category/Details?categoryId={doctor.Id}", doctor);
            }
            return BadRequest(doctor);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int doctorId)
        {
            var doctor = doctorRepository.GetOne([], e => e.Id == doctorId);
            if (doctor != null)
            {
                doctorRepository.Delete(doctor);
                doctorRepository.Save();
                return Ok();
            }
            return NotFound();
        }
    }
}
