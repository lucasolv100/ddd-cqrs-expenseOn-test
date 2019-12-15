using Hotel.Domain.Interfaces;

namespace Hotel.Domain.Repositories
{
    public interface IHotelRepository : IRepository<Domain.Entites.Hotel>
    {
         bool IsHotelExists(int id);
    }
}