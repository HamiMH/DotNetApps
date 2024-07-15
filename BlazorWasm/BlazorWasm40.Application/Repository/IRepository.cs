using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm40.Application.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> func);

        Task Add(TEntity entity);

        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        Task Save();
    }
}
