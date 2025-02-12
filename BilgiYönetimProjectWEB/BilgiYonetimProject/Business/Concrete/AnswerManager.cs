using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AnswerManager : IAnswerService
    {
        IAnswerDal _answerDal;
        public AnswerManager(IAnswerDal answerDal)
        {
            _answerDal = answerDal;
        }



        public IDataResult<List<Answer>> GetAll()
        {
            return new SuccessDataResult<List<Answer>>(_answerDal.GetAll());
        }

        public IDataResult<Answer> GetById(int answerId)
        {
            return new SuccessDataResult<Answer>(_answerDal.Get(a => a.AnswerId == answerId));
        }
        public IResult Add(Answer answer)
        {
            _answerDal.Add(answer);
            return new SuccessResult("Answer added successfully.");
        }


        public IResult Update(Answer answer)
        {
            _answerDal.Update(answer);
            return new SuccessResult("Answer updated successfully.");
        }

        public IResult Delete(Answer answer)
        {
            _answerDal.Delete(answer);
            return new SuccessResult("Deleted");

        }
    }
}
