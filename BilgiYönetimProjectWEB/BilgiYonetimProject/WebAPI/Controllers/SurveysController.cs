using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private readonly IProcessService _processService;
        private readonly IQuestionGroupService _questionGroupService;
        private readonly IUserService _userService;

        public SurveysController(ISurveyService surveyService, IProcessService processService, IQuestionGroupService questionGroupService, IUserService userService)
        {
            _surveyService = surveyService;
            _processService = processService;
            _questionGroupService = questionGroupService;
            _userService = userService;
        }


        [HttpGet("count")]
        public IActionResult GetSurveyCount()
        {
            var result = _surveyService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data.Count);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _surveyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _surveyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Survey survey)
        {
            var result = _surveyService.Add(survey);
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
        [HttpPost("addandsurveyid")]
        public IActionResult AddAndSurveyId(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _surveyService.Add(survey);
            if (result.Success)
            {
                try
                {
                    var addedSurvey = _surveyService.GetById(survey.SurveyId); // Yeni eklenen survey'in id'sini al
                    if (addedSurvey.Success)
                    {
                        return Ok(new { success = true, data = new { surveyId = addedSurvey.Data.SurveyId } });
                    }
                }
                catch (Exception ex)
                {
                    // Hata loglama
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return StatusCode(500, "Internal server error");
                }
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Survey survey)
        {
            var result = _surveyService.Update(survey);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updatescore")]
        public IActionResult UpdateScore([FromBody] UpdateScoreRequest request)
        {
            var survey = _surveyService.GetById(request.SurveyId).Data;
            if (survey == null)
            {
                return NotFound(new { success = false, message = "Survey not found." });
            }

            survey.SurveyScore = request.SurveyScore;
            var result = _surveyService.Update(survey);

            if (result.Success)
            {
                return Ok(new { success = true, message = "Survey score updated successfully." });
            }
            return BadRequest(new { success = false, message = "Failed to update survey score." });
        }
        [HttpGet("getsurveyinfo/{surveyId}")]
        public IActionResult GetSurveyInfo(int surveyId)
        {
            var survey = _surveyService.GetById(surveyId).Data;
            if (survey == null)
            {
                return NotFound(new { success = false, message = "Survey not found." });
            }

            var process = _processService.GetById(survey.ProcessId.GetValueOrDefault()).Data;
            var questionGroup = _questionGroupService.GetById(survey.QuestionGroupId.GetValueOrDefault()).Data;
            var auditor = _userService.GetByUserCode(survey.AuditorName).Data;

            var surveyInfo = new
            {
                SurveyId = survey.SurveyId,
                ProcessName = process?.ProcessName,
                QuestionGroupName = questionGroup?.QuestionGroupName,
                AuditorName = $"{auditor?.UserName} {auditor?.UserSurname}",
                SurveyDate = survey.SurveyDate,
                SurveyScore = survey.SurveyScore
            };

            return Ok(new { success = true, data = surveyInfo });
        }
        public class UpdateScoreRequest
        {
            public int SurveyId { get; set; }
            public int SurveyScore { get; set; }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var survey = _surveyService.GetById(id).Data;
                if (survey == null)
                {
                    return NotFound(new { success = false, message = "Survey not found." });
                }

                var result = _surveyService.Delete(survey);
                if (result.Success)
                {
                    return Ok(new { success = true, message = "Survey deleted successfully." });
                }
                return BadRequest(new { success = false, message = "Failed to delete survey." });
            }
            catch (Exception ex)
            {
                // Hata loglama
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Internal server error.", error = ex.Message });
            }
        }
    }
}
