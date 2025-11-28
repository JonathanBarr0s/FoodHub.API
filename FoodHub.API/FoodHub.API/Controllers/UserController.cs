using FoodHub.API.Dtos.User;
using FoodHub.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodHub.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;

		public UserController(IUserService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var dto = await _service.GetByIdAsync(id);
			if (dto == null)
				return NotFound();
			return Ok(dto);
		}

		[HttpPost]
		public async Task<IActionResult> Create(UserCreateDto dto)
		{
			var created = await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UserUpdateDto dto)
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
