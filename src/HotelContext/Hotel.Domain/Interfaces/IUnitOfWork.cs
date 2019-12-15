using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface IUnitOfWork
    {
         Task Commit();
    }
}