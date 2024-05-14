using ClinicApi.Interfaces;
using ClinicApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService; 
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Doctor> doctors = await _doctorService.GetAll();
                return Ok(doctors);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(int id, int experience)
        {
            try
            {
                Doctor doc = await _doctorService.UpdateDoctorExperience(id, experience);
                return Ok(doc);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
        
        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> Filter(string speciality)
        {
            try
            {
                IEnumerable<Doctor> doctors = await _doctorService.FilterDoctorBasedOnSpeciality(speciality);
                return Ok(doctors);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
