using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly IDealerService _dealerService;

        public DealersController(IDealerService dealerService)
        {
            _dealerService = dealerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _dealerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(new
            {
                success = false,
                message = result.Message
            });
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _dealerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(new
            {
                success = false,
                message = result.Message
            });
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Dealer dealer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Validation errors occurred.",
                    errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                });
            }

            var result = _dealerService.Add(dealer);
            if (result.Success)
            {
                return Ok(new
                {
                    success = true,
                    message = result.Message
                });
            }
            return BadRequest(new
            {
                success = false,
                message = result.Message
            });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] Dealer dealer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Validation errors occurred.",
                    errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                });
            }

            var result = _dealerService.Update(dealer);
            if (result.Success)
            {
                return Ok(new
                {
                    success = true,
                    message = result.Message
                });
            }
            return BadRequest(new
            {
                success = false,
                message = result.Message
            });
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] Dealer dealer)
        {
            var result = _dealerService.Delete(dealer);
            if (result.Success)
            {
                return Ok(new
                {
                    success = true,
                    message = result.Message
                });
            }
            return BadRequest(new
            {
                success = false,
                message = result.Message
            });
        }
    }
}
