using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IQuestionService
    {
   
        IDataResult<Question> GetById(int questionId);
        IDataResult<List<Question>> GetAll();
        IResult Add(Question question);
        IResult Update(Question question);
        IResult Delete(int id);
        IDataResult<List<Question>> GetByQuestionGroupId(int questionGroupId);
    }
}
