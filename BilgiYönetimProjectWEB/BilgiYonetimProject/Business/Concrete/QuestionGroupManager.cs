using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class QuestionGroupManager : IQuestionGroupService
    {
        IQuestionGroupDal _questionGroupDal;

        public QuestionGroupManager(IQuestionGroupDal questionGroupDal)
        {
            _questionGroupDal = questionGroupDal;
        }

        public IDataResult<List<QuestionGroup>> GetAll()
        {
            return new SuccessDataResult<List<QuestionGroup>> (_questionGroupDal.GetAll());
        }

        public IDataResult<QuestionGroup> GetById(int groupId)
        {
            return new SuccessDataResult<QuestionGroup>(_questionGroupDal.Get(qg => qg.QuestionGroupId == groupId));
        }
        public IResult Add(QuestionGroup questionGroup)
        {
            _questionGroupDal.Add(questionGroup);
            return new SuccessResult(Messages.QuestionGroupAdded);
        }

        public IResult Update(QuestionGroup questionGroup)
        {
            _questionGroupDal.Update(questionGroup);
            return new SuccessResult(Messages.QuestionGroupUpdated);
        }

        public IResult Delete(QuestionGroup questionGroup)
        {
            _questionGroupDal.Delete(questionGroup);
            return new SuccessResult(Messages.QuestionGroupDeleted);
        }
        public IDataResult<List<QuestionGroup>> GetByProcessId(int processId)
        {
            var result = _questionGroupDal.GetAll(q => q.QuestionProcessId == processId);
            return new SuccessDataResult<List<QuestionGroup>>(result);
        }
    }
}
