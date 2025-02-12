using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarModelManager : ICarModelService
    {
        private readonly ICarModelDal _carModelDal;

        public CarModelManager(ICarModelDal carModelDal)
        {
            _carModelDal = carModelDal;
        }

        public IDataResult<List<CarModel>> GetAll()
        {
            return new SuccessDataResult<List<CarModel>>(_carModelDal.GetAll());
        }

        public IDataResult<CarModel> GetById(int carModelId)
        {
            return new SuccessDataResult<CarModel>(_carModelDal.Get(cm => cm.CarModelId == carModelId));
        }

        public IResult Add(CarModel carModel)
        {
            _carModelDal.Add(carModel);
            return new SuccessResult("Car model added successfully.");
        }

        public IResult Update(CarModel carModel)
        {
            _carModelDal.Update(carModel);
            return new SuccessResult("Car model updated successfully.");
        }

        public IResult Delete(CarModel carModel)
        {
            _carModelDal.Delete(carModel);
            return new SuccessResult("Car model deleted successfully.");
        }
    }
}
