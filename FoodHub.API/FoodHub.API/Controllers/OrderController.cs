using FoodHub.API.Dtos.Order;
using FoodHub.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodHub.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _service;

		public OrderController(IOrderService service)
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
		public async Task<IActionResult> Create(OrderCreateDto dto)
		{
			var created = await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, OrderUpdateDto dto)
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
