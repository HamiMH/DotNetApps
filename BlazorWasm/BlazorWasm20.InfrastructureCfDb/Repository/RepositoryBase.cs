using BlazorWasm40.Application.Repository;
using BlazorWasm60.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm20.InfrastructureCfDb.Repository
{
    internal abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IIdentifiable
    {
        protected GamesDbContext GamesDbContext;
        protected RepositoryBase(GamesDbContext gamesDbContext)
        {
            GamesDbContext = gamesDbContext;
        }
        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> func)
        {
            return GamesDbContext.Set<TEntity>().Where(func);
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return GamesDbContext.Set<TEntity>();

            }
            catch (Exception)
            {
                throw;
            }

        }

        public TEntity GetById(int id)
        {
            return GamesDbContext.Set<TEntity>().Where(t => (t.Id == id)).FirstOrDefault();
        }
    }
}
