using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAnswerService
    {
        
        IDataResult<List<Answer>> GetAll();
        IDataResult<Answer> GetById(int answerId);
        IResult Add(Answer answer);
        IResult Update(Answer answer);
        IResult Delete(Answer answer);
       
    }
}
