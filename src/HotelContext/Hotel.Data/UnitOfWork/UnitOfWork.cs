using System.Threading.Tasks;
using Hotel.Domain.Interfaces;

namespace Hotel.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelContext _context;

        public UnitOfWork(HotelContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}