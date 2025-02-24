using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCar.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext = null;

        private readonly DbSet<T> table = null;

        public BaseRepository()
        {
            _appDbContext = new AppDbContext();
            table = _appDbContext.Set<T>();
        }

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            table = _appDbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await table.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            await table.Remove(entity).Context.SaveChangesAsync();

            return null;
        }

        public IQueryable<T> GetAll()
        {
            return table.AsNoTracking();
        }

        public IQueryable<T> GetByWhere(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).AsNoTracking();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await table.Update(entity).Context.SaveChangesAsync();

            return entity;
        }
    }
}