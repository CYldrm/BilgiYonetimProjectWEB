using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private readonly ICarModelService _carModelService;

        public CarModelsController(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carModelService.GetAll();
            if (result.Success)
            {
                return Ok(result); // Tüm result nesnesini döndürüyoruz
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
            var result = _carModelService.GetById(id);
            if (result.Success)
            {
                return Ok(result); // Tüm result nesnesini döndürüyoruz
            }
            return BadRequest(new
            {
                success = false,
                message = result.Message
            });
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CarModel carModel)
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

            var result = _carModelService.Add(carModel);
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
        public IActionResult Update([FromBody] CarModel carModel)
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

            var result = _carModelService.Update(carModel);
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
        public IActionResult Delete([FromBody] CarModel carModel)
        {
            var result = _carModelService.Delete(carModel);
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
