using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProcessManager : IProcessService
    {
        IProcessDal _processDal;

        public ProcessManager(IProcessDal processDal)
        {
            _processDal = processDal;
        }

        public IDataResult<List<Process>> GetAll()
        {
            return new SuccessDataResult<List<Process>>(_processDal.GetAll());
        }

        public IDataResult<Process> GetById(int processId)
        {
            return new SuccessDataResult<Process>(_processDal.Get(p => p.ProcessId == processId));
        }
        public IResult Add(Process process)
        {
            _processDal.Add(process);
            return new SuccessResult("Process added successfully.");
        }

        public IResult Update(Process process)
        {
            _processDal.Update(process);
            return new SuccessResult("Process updated successfully.");
        }

        public IResult Delete(Process process)
        {
            _processDal.Delete(process);
            return new SuccessResult("Process deleted successfully.");
        }
    }
}
