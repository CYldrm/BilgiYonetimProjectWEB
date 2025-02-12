using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{

    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public IDataResult<List<Question>> GetAll()
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll());
        }
        public IDataResult<List<Question>> GetByQuestionGroupId(int questionGroupId)
        {
            var result = _questionDal.GetAll(q => q.QuestionGroupId == questionGroupId);
            return new SuccessDataResult<List<Question>>(result);
        }
        public IDataResult<Question> GetById(int questionId)
        {
            return new SuccessDataResult<Question>(_questionDal.Get(q => q.QuestionId == questionId));
        }
        public IResult Add(Question question)
        {
            _questionDal.Add(question);
            return new SuccessResult("Question added successfully.");
        }

        public IResult Update(Question question)
        {
            _questionDal.Update(question);
            return new SuccessResult("Question updated successfully.");
        }

        public IResult Delete(int id)
        {
            var question = _questionDal.Get(q => q.QuestionId == id);
            if (question == null)
            {
                return new ErrorResult("Question not found.");
            }
            _questionDal.Delete(question);
            return new SuccessResult("Question deleted successfully.");
        }






    }
}

