using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _adminService.GetAll();
            if (result.Success)
            {
                return Ok(result); // Tüm result nesnesini döndürüyoruz
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _adminService.GetById(id);
            if (result.Success)
            {
                return Ok(result); // Tüm result nesnesini döndürüyoruz
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Model validation failed",
                    errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                });
            }

            var result = _adminService.Add(admin);
            if (result.Success)
            {
                return Ok(result); // Tüm result nesnesini döndürüyoruz
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Model validation failed",
                    errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                });
            }

            var result = _adminService.Update(admin);
            if (result.Success)
            {
                return Ok(result); // Tüm result nesnesini döndürüyoruz
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] Admin admin)
        {
            var result = _adminService.Delete(admin);
            if (result.Success)
            {
                return Ok(result); // Tüm result nesnesini döndürüyoruz
            }
            return BadRequest(result);
        }
    }
}
