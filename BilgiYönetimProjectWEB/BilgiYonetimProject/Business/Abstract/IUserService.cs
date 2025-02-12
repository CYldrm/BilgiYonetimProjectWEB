using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IResult Add(User user);
        User GetUserByMailAndPassword(string userMail, string userPassword);
        IResult Update(User user); // Update metodu
        IResult Delete(User user); // Delete metodu
        IDataResult<User> GetByUserCode(string userCode);

    }
   
}
