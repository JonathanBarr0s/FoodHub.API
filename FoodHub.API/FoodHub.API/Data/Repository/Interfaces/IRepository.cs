using FoodHub.API.Domain.Base;

namespace FoodHub.API.Data.Repository.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
		Task AddAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
		Task<bool> SaveChangesAsync();
	}
}
