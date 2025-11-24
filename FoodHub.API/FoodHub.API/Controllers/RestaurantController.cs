using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodHub.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RestaurantController : ControllerBase
	{
		private readonly IRepository<Restaurant> _repository;

		public RestaurantController(IRepository<Restaurant> repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var restaurants = await _repository.GetAllAsync();
			return Ok(restaurants);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var restaurants = await _repository.GetByIdAsync(id);
			if (restaurants == null)
				return NotFound();

			return Ok(restaurants);
		}

		[HttpPost]
		public async Task<IActionResult> Create(Restaurant restaurant)
		{
			await _repository.AddAsync(restaurant);
			await _repository.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = restaurant.Id }, restaurant);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Restaurant restaurant)
		{
			var existing = await _repository.GetByIdAsync(id);
			if (existing == null)
				return NotFound();

			existing.Name = restaurant.Name;
			existing.Address = restaurant.Address;

			_repository.Update(existing);
			await _repository.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var restaurant = await _repository.GetByIdAsync(id);
			if (restaurant == null)
				return NotFound();

			_repository.Delete(restaurant);
			await _repository.SaveChangesAsync();

			return NoContent();
		}
	}
}