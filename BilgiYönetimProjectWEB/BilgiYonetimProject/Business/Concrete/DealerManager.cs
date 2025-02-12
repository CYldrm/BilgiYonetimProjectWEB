using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class DealerManager : IDealerService
    {
        private readonly IDealerDal _dealerDal;

        public DealerManager(IDealerDal dealerDal)
        {
            _dealerDal = dealerDal;
        }

        public IDataResult<List<Dealer>> GetAll()
        {
            return new SuccessDataResult<List<Dealer>>(_dealerDal.GetAll());
        }

        public IDataResult<Dealer> GetById(int dealerId)
        {
            return new SuccessDataResult<Dealer>(_dealerDal.Get(d => d.DealerId == dealerId));
        }

        public IResult Add(Dealer dealer)
        {
            _dealerDal.Add(dealer);
            return new SuccessResult("Dealer added successfully.");
        }

        public IResult Update(Dealer dealer)
        {
            _dealerDal.Update(dealer);
            return new SuccessResult("Dealer updated successfully.");
        }

        public IResult Delete(Dealer dealer)
        {
            _dealerDal.Delete(dealer);
            return new SuccessResult("Dealer deleted successfully.");
        }
    }
}
