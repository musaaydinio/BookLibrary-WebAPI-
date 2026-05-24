
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF_Core
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        protected readonly RepositoriesContex _contex;

        protected RepositoryBase(RepositoriesContex contex)
        {
            _contex = contex;
        }
        public void Create(T entity) => _contex.Set<T>().Add(entity);

        public void Delete(T entity) => _contex.Set<T>().Remove(entity);


        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? _contex.Set<T>()
            .AsNoTracking() : _contex.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expressio,
            bool trackChanges) => !trackChanges ? _contex.Set<T>().Where(expressio).AsNoTracking() :
            _contex.Set<T>().Where(expressio);
        public void Update(T entity) => _contex.Set<T>().Update(entity);

    }
}
