using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetSingle(int id);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Create(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);

     
    }
}
