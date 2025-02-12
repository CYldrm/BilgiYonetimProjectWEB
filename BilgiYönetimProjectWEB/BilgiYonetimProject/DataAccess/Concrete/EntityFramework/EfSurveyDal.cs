using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSurveyDal : EfEntityRepositoryBase<Survey, NorthwindContext>, ISurveyDal
    {
        public List<SurveyDetailDto> GetSurveyDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from s in context.Survey
                             join p in context.Process on s.SurveyId equals p.ProcessId
                             join q in context.QuestionGroup on s.SurveyId equals q.QuestionGroupId

                             select new SurveyDetailDto
                             {
                                 
                                 SurveyId = s.SurveyId,
                                 SurveyDate = s.SurveyDate,
                                 AuditorName = s.AuditorName,
                                 CreateDate = s.CreateDate,
                                 CreateUser = s.CreateUser
                                                              ,
                                 ProcessDescription = p.ProcessDescription,
                                 ProcessId = p.ProcessId,
                                 ProcessName = p.ProcessName
                                                        ,
                                 ProcessStatus = p.ProcessStatus,
                                 SurveyScore = s.SurveyScore,
                                 QuestionGroupDescription = q.QuestionGroupDescription,
                                 QuestionGroupId = q.QuestionGroupId,
                                 QuestionGroupName = q.QuestionGroupName
                                                           ,
                                 QuestionIsDefault = q.QuestionIsDefault,
                                 QuestionProcessId = q.QuestionProcessId
                             };
                return result.ToList();      
            }
        }
    }
}
