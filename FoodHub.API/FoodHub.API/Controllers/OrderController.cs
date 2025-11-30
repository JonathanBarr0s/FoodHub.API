using FoodHub.API.Dtos.Order;
using FoodHub.API.Services.Implementations;
using FoodHub.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodHub.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _service;

		public OrderController(IOrderService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
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
		public async Task<IActionResult> Create([FromBody] OrderCreateDto dto)
		{
			try
			{
				var order = await _service.CreateAsync(dto);
				return Ok(order);
			} catch (InvalidOperationException ex)
			{

				return BadRequest(new { error = ex.Message });
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> AddItem(int id, [FromBody] OrderAddItemDto dto)
		{
			try
			{
				dto.OrderId = id;

				var result = await _service.AddItemAsync(dto);

				return Ok(result);

			} catch (InvalidOperationException ex)
			{
				return BadRequest(new { error = ex.Message });
			}
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