using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAdminService
    {
        IDataResult<List<Admin>> GetAll();
        IDataResult<Admin> GetById(int adminId);
        IResult Add(Admin admin);
        IResult Update(Admin admin);
        IResult Delete(Admin admin);
    }
}
