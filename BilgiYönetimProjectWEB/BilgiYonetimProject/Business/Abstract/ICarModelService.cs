using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarModelService
    {
        IDataResult<List<CarModel>> GetAll();
        IDataResult<CarModel> GetById(int carModelId);
        IResult Add(CarModel carModel);
        IResult Update(CarModel carModel);
        IResult Delete(CarModel carModel);
    }
}
