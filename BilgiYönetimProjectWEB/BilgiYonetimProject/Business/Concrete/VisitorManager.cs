using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class VisitorManager : IVisitorService
    {
        private readonly IVisitorDal _visitorDal;

        public VisitorManager(IVisitorDal visitorDal)
        {
            _visitorDal = visitorDal;
        }

        public IDataResult<List<Visitor>> GetAll()
        {
            return new SuccessDataResult<List<Visitor>>(_visitorDal.GetAll(), "Visitors listed successfully.");
        }

        public IDataResult<Visitor> GetById(int visitorId)
        {
            var visitor = _visitorDal.Get(v => v.VisitorId == visitorId);
            return visitor != null
                ? new SuccessDataResult<Visitor>(visitor, "Visitor found.")
                : new ErrorDataResult<Visitor>("Visitor not found.");
        }

        public IResult Add(Visitor visitor)
        {
            _visitorDal.Add(visitor);
            return new SuccessResult("Visitor added successfully.");
        }

        public IResult Update(Visitor visitor)
        {
            _visitorDal.Update(visitor);
            return new SuccessResult("Visitor updated successfully.");
        }

        public IResult Delete(Visitor visitor)
        {
            _visitorDal.Delete(visitor);
            return new SuccessResult("Visitor deleted successfully.");
        }
    }
}
