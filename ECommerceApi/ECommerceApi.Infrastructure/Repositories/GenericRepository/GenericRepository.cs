using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceApi.Infrastructure.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        #region Read Operations

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging
                throw new InvalidOperationException($"Error retrieving all {typeof(T).Name} entities", ex);
            }
        }

        public virtual async Task<T?> GetByIdAsync(object id)
        {
            try
            {
                if (id == null)
                    return null;

                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving {typeof(T).Name} entity with id {id}", ex);
            }
        }

        public virtual async Task<T?> GetByIdAsync(params object[] keyValues)
        {
            try
            {
                if (keyValues == null || keyValues.Length == 0)
                    return null;

                return await _dbSet.FindAsync(keyValues);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving {typeof(T).Name} entity with composite key", ex);
            }
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                if (expression == null)
                    throw new ArgumentNullException(nameof(expression));

                return await _dbSet.Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error finding {typeof(T).Name} entities", ex);
            }
        }

        public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                if (expression == null)
                    throw new ArgumentNullException(nameof(expression));

                return await _dbSet.FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error finding first {typeof(T).Name} entity", ex);
            }
        }

        #endregion

        #region Write Operations

        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                await _dbSet.AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error adding {typeof(T).Name} entity", ex);
            }
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                await _dbSet.AddRangeAsync(entities);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error adding multiple {typeof(T).Name} entities", ex);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _dbSet.Update(entity);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error updating {typeof(T).Name} entity", ex);
            }
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                _dbSet.UpdateRange(entities);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error updating multiple {typeof(T).Name} entities", ex);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error deleting {typeof(T).Name} entity", ex);
            }
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                _dbSet.RemoveRange(entities);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error deleting multiple {typeof(T).Name} entities", ex);
            }
        }

        #endregion

        #region Save Operations

        public virtual async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Error saving changes to the database", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An unexpected error occurred while saving", ex);
            }
        }

        #endregion

        #region Utility Methods

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                if (expression == null)
                    throw new ArgumentNullException(nameof(expression));

                return await _dbSet.AnyAsync(expression);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error checking existence of {typeof(T).Name} entity", ex);
            }
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null)
        {
            try
            {
                if (expression == null)
                    return await _dbSet.CountAsync();

                return await _dbSet.CountAsync(expression);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error counting {typeof(T).Name} entities", ex);
            }
        }

        #endregion
    }
}
