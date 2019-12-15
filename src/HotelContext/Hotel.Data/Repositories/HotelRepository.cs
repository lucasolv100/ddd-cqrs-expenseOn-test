using System.Collections.Generic;
using System.Linq;
using Hotel.Domain.Entites;
using Hotel.Domain.Interfaces;
using Hotel.Domain.Repositories;

namespace Hotel.Data.Repositories
{
    public class HotelRepository : Repository<Domain.Entites.Hotel>, IHotelRepository
    {
        public HotelRepository(HotelContext context) : base(context)
        {

        }

        public override IEnumerable<Domain.Entites.Hotel> GetAll()
        {
            return  _context.AnuncioWebmotors
                    .Where(q => q.DeleteDate == null).ToList();
        }
        public override Domain.Entites.Hotel GetById(int id)
        {
            return  _context.AnuncioWebmotors
                    .Where(q => q.DeleteDate == null && q.Id == id).FirstOrDefault();
        }

        public bool IsHotelExists(int id)
        {
            return  _context.AnuncioWebmotors
                    .Where(q => q.DeleteDate == null && q.Id == id).Any();
        }
    }
}