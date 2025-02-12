using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IQuestionGroupService
    {
        IDataResult<List<QuestionGroup>> GetAll();
        IDataResult<QuestionGroup> GetById(int questionGroupId);
        IResult Add(QuestionGroup questionGroup);
        IResult Update(QuestionGroup questionGroup); // Update metodu
        IResult Delete(QuestionGroup questionGroup); // Delete metodu
        IDataResult<List<QuestionGroup>> GetByProcessId(int processId);
    }
   
}
