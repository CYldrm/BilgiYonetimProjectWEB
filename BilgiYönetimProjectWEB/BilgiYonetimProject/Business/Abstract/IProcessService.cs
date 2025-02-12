using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProcessService
    {
        IDataResult<List<Process>> GetAll();
        IDataResult<Process> GetById(int processId);
        IResult Add(Process process);
        IResult Update(Process process);
        IResult Delete(Process process);
    }
}
