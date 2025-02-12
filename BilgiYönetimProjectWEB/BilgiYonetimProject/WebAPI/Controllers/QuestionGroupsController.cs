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
    public class QuestionGroupsController : ControllerBase
    {
        private readonly IQuestionGroupService _questionGroupService;

        public QuestionGroupsController(IQuestionGroupService questionGroupService)
        {
            _questionGroupService = questionGroupService;
        }

        [HttpGet("count")]
        public IActionResult GetQuestionGroupCount()
        {
            var result = _questionGroupService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data.Count);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _questionGroupService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _questionGroupService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Post(QuestionGroup questionGroup)
        {
            var result = _questionGroupService.Add(questionGroup);
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
        public IActionResult Update(QuestionGroup questionGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _questionGroupService.Update(questionGroup);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(QuestionGroup questionGroup)
        {
            var result = _questionGroupService.Delete(questionGroup);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyprocessid")]
        public IActionResult GetByProcessId(int processId)
        {
            var result = _questionGroupService.GetByProcessId(processId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
