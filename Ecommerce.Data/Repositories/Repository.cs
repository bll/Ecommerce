using Ecommerce.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(AppDbContext context) {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task AddAsnyc(TEntity entity) {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate) {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsnyc() {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id) {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity) {

            var deletedAtProperty = entity.GetType().GetProperty("IsDeleted");
            if (deletedAtProperty == null) {
                _dbSet.Remove(entity);
            }
            else {
                entity.GetType().GetProperty("IsDeleted")?.SetValue(entity, true);
                _dbSet.Update(entity);
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities) {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate) {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(predicate);
        }
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(predicate);
        }
        public TEntity Update(TEntity entity) {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
