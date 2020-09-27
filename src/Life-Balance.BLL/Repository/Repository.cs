using Life_Balance.Common.Interfaces;
using Life_Balance.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Life_Balance.BLL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _context;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="context"></param>
        public Repository(LifeBalanceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Add object in database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        /// <summary>
        /// Add new entities async.
        /// </summary>
        /// <param name="entities">Entity collection.</param>
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        /// <summary>
        /// Remove object from database.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Remove all object from database.
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        /// <summary>
        /// Get all queries.
        /// </summary>
        /// <returns>IQueryable queries</returns>
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        /// <summary>
        /// Get entity async by predicate.
        /// </summary>
        /// <param name="predicate">LINQ predicate.</param>
        /// <returns></returns>
        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Persists all updates to the data source async.
        /// </summary>
        /// <returns>Save object.</returns>
        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
