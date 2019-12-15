using System.Collections.Generic;
using Hotel.Domain.Core.Entities;
using Hotel.Domain.Interfaces;

namespace Hotel.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly HotelContext _context;

        public Repository(
            HotelContext context

        )
        {
            _context = context;
        }

        public void Delete(TEntity obj)
        {
            _context.Update(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public virtual TEntity GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(TEntity obj)
        {
            _context.Add(obj);
        }

        public void Update(TEntity obj)
        {
            _context.Update(obj);
        }
    }
}