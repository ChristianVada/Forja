using Microsoft.AspNetCore.Mvc;
using static WebApplication2.AnelService;

namespace WebApplication2
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnelController : ControllerBase
    {
        private readonly IAnelService _anelService;

        public AnelController(IAnelService anelService)
        {
            _anelService = anelService;
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_anelService.Listar());

        [HttpPost]
        public IActionResult Criar([FromBody] AnelEntity anel)
        {
            try
            {
                return Ok(_anelService.Criar(anel));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] AnelEntity anel)
        {
            try
            {
                return Ok(_anelService.Atualizar(id, anel));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _anelService.Deletar(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
