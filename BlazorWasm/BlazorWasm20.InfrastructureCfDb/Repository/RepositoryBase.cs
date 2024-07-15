using BlazorWasm40.Application.Repository;
using BlazorWasm60.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task Add(TEntity entity)
        {
            try
            {
                await GamesDbContext.Set<TEntity>().AddAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                await GamesDbContext.Set<TEntity>().AddRangeAsync(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(TEntity entity)
        {
            try
            {
                GamesDbContext.Set<TEntity>().Remove(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                TEntity? entityToDel= await GamesDbContext.Set<TEntity>().Where(t => (t.Id == id)).FirstAsync();
                if (entityToDel == null)
                    return;
                GamesDbContext.Set<TEntity>().Remove(entityToDel);
            }
            catch(Exception) 
            {
                throw;
            }

        }

        public async Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> func)
        {
            try
            {
                return await GamesDbContext.Set<TEntity>().Where(func).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await GamesDbContext.Set<TEntity>().ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            try
            {
                return await GamesDbContext.Set<TEntity>().Where(t => (t.Id == id)).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Save()
        {
            try
            {
                await GamesDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(TEntity entity)
        {
            try
            {
                GamesDbContext.Set<TEntity>().Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                GamesDbContext.Set<TEntity>().UpdateRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
