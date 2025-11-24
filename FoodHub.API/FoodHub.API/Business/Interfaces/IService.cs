using FoodHub.API.Domain.Base;

namespace FoodHub.API.Business.Interfaces
{
	public interface IService<T> where T : BaseEntity
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T?> GetByIdAsync(int id);
		Task<T> AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(int id);
	}
}