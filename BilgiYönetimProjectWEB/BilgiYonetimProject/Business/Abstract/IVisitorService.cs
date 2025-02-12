using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IVisitorService
    {
        IDataResult<List<Visitor>> GetAll();
        IDataResult<Visitor> GetById(int visitorId);
        IResult Add(Visitor visitor);
        IResult Update(Visitor visitor);
        IResult Delete(Visitor visitor);
    }
}
