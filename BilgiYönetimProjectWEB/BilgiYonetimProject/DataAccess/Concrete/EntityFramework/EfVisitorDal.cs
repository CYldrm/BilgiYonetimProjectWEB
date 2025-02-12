using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfVisitorDal : EfEntityRepositoryBase<Visitor, NorthwindContext>, IVisitorDal
    {
    }
}
