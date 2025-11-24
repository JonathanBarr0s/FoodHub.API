using FoodHub.API.Data.Context;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace FoodHub.API.Data.Repository.Implementations
{
	public class GenericRepository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly AppDbContext _context;
		private readonly DbSet<T> _dbSet;

		public GenericRepository(AppDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<bool> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}
	}
}