using System.Linq;
using Entities.Entities;

namespace Entities.Repositories
{
    public interface IRepo<T> : IRepo where T:Entity
    {
        void Create(T entity);
        IQueryable<T> GetAll();
        void Delete(T entity);
    }
}
