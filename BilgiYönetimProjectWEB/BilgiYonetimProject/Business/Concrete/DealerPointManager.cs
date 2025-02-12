using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class DealerPointManager : IDealerPointService
    {
        private readonly IDealerPointDal _dealerPointDal;

        public DealerPointManager(IDealerPointDal dealerPointDal)
        {
            _dealerPointDal = dealerPointDal;
        }

        public IDataResult<List<DealerPoint>> GetAll()
        {
            return new SuccessDataResult<List<DealerPoint>>(_dealerPointDal.GetAll(), "Dealer points listed successfully.");
        }

        public IDataResult<DealerPoint> GetById(int dealerPointId)
        {
            var dealerPoint = _dealerPointDal.Get(dp => dp.DealerPointId == dealerPointId);
            return dealerPoint != null
                ? new SuccessDataResult<DealerPoint>(dealerPoint, "Dealer point found.")
                : new ErrorDataResult<DealerPoint>("Dealer point not found.");
        }

        public IResult Add(DealerPoint dealerPoint)
        {
            _dealerPointDal.Add(dealerPoint);
            return new SuccessResult("Dealer point added successfully.");
        }

        public IResult Update(DealerPoint dealerPoint)
        {
            _dealerPointDal.Update(dealerPoint);
            return new SuccessResult("Dealer point updated successfully.");
        }

        public IResult Delete(DealerPoint dealerPoint)
        {
            _dealerPointDal.Delete(dealerPoint);
            return new SuccessResult("Dealer point deleted successfully.");
        }
    }
}
