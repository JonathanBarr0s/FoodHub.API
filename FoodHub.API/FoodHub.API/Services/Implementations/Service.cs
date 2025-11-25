using FoodHub.API.Services.Interfaces;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Base;

namespace FoodHub.API.Services.Implementations
{
	public class Service<T> : IService<T> where T : BaseEntity
	{
		private readonly IRepository<T> _repository;

		public Service(IRepository<T> repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task<T> AddAsync(T entity)
		{
			await _repository.AddAsync(entity);
			await _repository.SaveChangesAsync();
			return entity;
		}

		public async Task UpdateAsync(T entity)
		{
			_repository.Update(entity);
			await _repository.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity != null)
			{
				_repository.Delete(entity);
				await _repository.SaveChangesAsync();
			}
		}
	}
}