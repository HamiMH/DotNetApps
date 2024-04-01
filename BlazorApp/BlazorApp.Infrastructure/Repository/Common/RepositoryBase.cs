using BlazorApp.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Infrastructure.Repository.Common;

internal abstract class RepositoryBase<TEntity> : Application.Repository.Common.IRepository<TEntity> where TEntity : class
{

    protected readonly DbContext Context;

    public RepositoryBase(DbContext context)
    {  Context = context; }

    public abstract IEnumerable<TEntity> Filter(TEntity entity);

    public IEnumerable<TEntity> GetAll()
    {
        return Context.Set<TEntity>().ToList();
    }

    public TEntity GetById(int id)
    {

        return Context.Set<TEntity>().Find(id);
    }
}
