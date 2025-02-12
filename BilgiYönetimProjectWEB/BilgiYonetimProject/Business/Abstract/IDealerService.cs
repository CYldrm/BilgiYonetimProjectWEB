using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDealerService
    {
        IDataResult<List<Dealer>> GetAll();
        IDataResult<Dealer> GetById(int dealerId);
        IResult Add(Dealer dealer);
        IResult Update(Dealer dealer);
        IResult Delete(Dealer dealer);
    }
}
