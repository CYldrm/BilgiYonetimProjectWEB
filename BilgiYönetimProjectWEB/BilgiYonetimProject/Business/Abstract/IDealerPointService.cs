using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDealerPointService
    {
        IDataResult<List<DealerPoint>> GetAll();
        IDataResult<DealerPoint> GetById(int dealerPointId);
        IResult Add(DealerPoint dealerPoint);
        IResult Update(DealerPoint dealerPoint);
        IResult Delete(DealerPoint dealerPoint);
    }
}
