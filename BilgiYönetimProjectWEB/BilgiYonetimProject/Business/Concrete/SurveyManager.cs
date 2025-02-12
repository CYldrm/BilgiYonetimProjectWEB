using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SurveyManager:ISurveyService
    {
        ISurveyDal _surveyDal;
        public SurveyManager(ISurveyDal surveyDal)
        {
            _surveyDal = surveyDal;
        }

        public IDataResult<List<Survey>> GetAll()
        {
            return new SuccessDataResult < List < Survey >>(_surveyDal.GetAll());
        }

       

        public IDataResult<Survey> GetById(int surveyId)
        {
            return new SuccessDataResult<Survey>(_surveyDal.Get(s => s.SurveyId == surveyId));
        }

       

        public IDataResult<List<SurveyDetailDto>> GetSurveyDetails()
        {
            return new SuccessDataResult<List<SurveyDetailDto>>(_surveyDal.GetSurveyDetails());
        }
        public IDataResult<Survey> Add(Survey survey)
        {
            _surveyDal.Add(survey);
            return new SuccessDataResult<Survey>(survey, "Survey added successfully.");
        }

        public IResult Update(Survey survey)
        {
            _surveyDal.Update(survey);
            return new SuccessResult("Survey updated successfully.");
        }
        public IResult UpdateScore(int surveyId, int surveyScore)
        {
            var survey = _surveyDal.Get(s => s.SurveyId == surveyId);
            if (survey == null)
            {
                return new ErrorResult("Survey not found.");
            }

            survey.SurveyScore = surveyScore;
            _surveyDal.Update(survey);
            return new SuccessResult("Survey score updated successfully.");
        }
        public IResult Delete(Survey survey)
        {
            _surveyDal.Delete(survey);
            return new SuccessResult("Survey deleted successfully.");
        }

    }

}
