using Forja.DTOs;
using Forja.Entities;
using Forja.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forja.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AnelController : ControllerBase
	{
		private readonly AnelService _service;

		public AnelController(AnelService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<LerAnelDTO>>> ListarAneis()
		{
			return Ok(await _service.ListarAneisAsync());
		}

		[HttpPost]
		public async Task<ActionResult<Anel>> RegistrarAnel([FromBody] CriarAnelDTO anelDto)
		{
			try
			{
				var anel = await _service.RegistrarAnelAsync(anelDto);
				return CreatedAtAction(nameof(ListarAneis), new { id = anel.Id }, anel);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Anel>> AtualizarAnel(Guid id, [FromBody] EditarAnelDTO anelDto)
		{
			var anelAtualizado = await _service.AtualizarAnelAsync(id, anelDto);
			if (anelAtualizado == null)
			{
				return NotFound();
			}

			return Ok(anelAtualizado);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletarAnel(Guid id)
		{
			var deletado = await _service.DeletarAnelAsync(id);
			if (!deletado)
			{
				return NotFound();
			}

			return NoContent();
		}
	}


}
