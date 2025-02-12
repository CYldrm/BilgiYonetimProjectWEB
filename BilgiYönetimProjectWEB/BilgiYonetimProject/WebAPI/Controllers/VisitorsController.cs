using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorService _visitorService;

        public VisitorsController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _visitorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _visitorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Visitor visitor)
        {
            // VisitorCode için rastgele 5 haneli sayı üret
            visitor.VisitorCode = GenerateVisitorCode();

            var result = _visitorService.Add(visitor);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        // 5 haneli rastgele sayı üreten metod
        private string GenerateVisitorCode()
        {
            Random random = new Random();
            return random.Next(10000, 99999).ToString(); // 10000 ile 99999 arasında bir sayı üret ve string'e çevir
        }
        [HttpPost("update")]
        public IActionResult Update(Visitor visitor)
        {
            var result = _visitorService.Update(visitor);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Visitor visitor)
        {
            var result = _visitorService.Delete(visitor);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
