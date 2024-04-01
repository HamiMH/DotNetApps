using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Application.Repository.Common;

   public  interface IRepository<TEntity> where TEntity : class
    {
    TEntity GetById(int id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Filter(TEntity entity);
}