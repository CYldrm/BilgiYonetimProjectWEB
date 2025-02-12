using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] User model)
        {
            try
            {
                var user = _userService.GetUserByMailAndPassword(model.UserMail, model.UserPassword);

                if (user == null)
                {
                    return BadRequest("Invalid email or password.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpGet("getall")]
        public IActionResult Get()
        {
         
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("count")]
        public IActionResult GetUserCount()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data.Count);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Post(User user)
        {
            var result = _userService.Add(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

    }

