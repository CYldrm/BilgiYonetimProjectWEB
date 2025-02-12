using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ISurveyDal : IEntityRepository<Survey>
    {
        List<SurveyDetailDto> GetSurveyDetails();
    }
}
