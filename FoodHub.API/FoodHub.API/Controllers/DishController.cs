using FoodHub.API.Dtos.Dish;
using FoodHub.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodHub.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DishController : ControllerBase
	{
		private readonly IDishService _service;

		public DishController(IDishService service)
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
		public async Task<IActionResult> Create(DishCreateDto dto)
		{
			try
			{
				var dish = await _service.AddAsync(dto);
				return Ok(dish);
			} catch (InvalidOperationException ex)
			{
				return BadRequest(new { error = ex.Message });
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, DishUpdateDto dto)
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