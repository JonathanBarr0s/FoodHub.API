using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.Restaurant;
using FoodHub.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodHub.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RestaurantController : ControllerBase
	{
		private readonly IRestaurantService _service;

		public RestaurantController(IRestaurantService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _service.GetAllAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _service.GetByIdAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create(RestaurantCreateDto dto)
		{
			var created = await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, RestaurantUpdateDto dto)
		{
			var updated = await _service.UpdateAsync(id, dto);
			if (!updated)
				return NotFound();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _service.DeleteAsync(id);
			if (!deleted)
				return NotFound();

			return NoContent();
		}
	}
}