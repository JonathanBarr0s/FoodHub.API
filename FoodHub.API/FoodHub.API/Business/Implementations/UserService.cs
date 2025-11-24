using FoodHub.API.Business.Interfaces;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;

namespace FoodHub.API.Business.Implementations
{
	public class UserService : Service<User>, IUserService
	{
		public UserService(IRepository<User> repository) : base(repository) { }
	}
}
