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
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> func);
    }
}
