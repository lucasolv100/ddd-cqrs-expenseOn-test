using System.Collections.Generic;

namespace Hotel.Domain.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Save(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
    }
}