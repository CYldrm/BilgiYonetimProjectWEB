using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
           IResult result = BusinessRules.Run(CheckIfUserMailExists(user.UserMail)); //iş kurallarını buraya ekle
           if(result != null)
            {
                return result;
            }
             _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
        public IDataResult<User> GetByUserCode(string userCode)
        {
            var result = _userDal.Get(u => u.UserCode == userCode);
            return new SuccessDataResult<User>(result);
        }
        public User GetUserByMailAndPassword(string userMail, string userPassword)
        {
            return _userDal.Get(u => u.UserMail == userMail && u.UserPassword == userPassword);
        }
        public IDataResult<List<User>> GetAll()
        {
            
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(c => c.UserId == userId));
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();

        }
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }
        private IResult CheckIfUserMailExists(string usermail)
        {
            var result = _userDal.GetAll(u=> u.UserMail ==usermail).Any();
            if(result) 
            {
                return new ErrorResult(Messages.UserMailAlreadyExists);
            }
            return new SuccessResult();

        }

    }
    
    }

