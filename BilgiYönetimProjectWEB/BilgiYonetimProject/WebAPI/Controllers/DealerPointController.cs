using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerPointsController : ControllerBase
    {
        private readonly IDealerPointService _dealerPointService;

        public DealerPointsController(IDealerPointService dealerPointService)
        {
            _dealerPointService = dealerPointService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _dealerPointService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _dealerPointService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(DealerPoint dealerPoint)
        {
            var result = _dealerPointService.Add(dealerPoint);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(DealerPoint dealerPoint)
        {
            var result = _dealerPointService.Update(dealerPoint);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DealerPoint dealerPoint)
        {
            var result = _dealerPointService.Delete(dealerPoint);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
