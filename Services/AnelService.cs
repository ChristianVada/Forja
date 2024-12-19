using Forja.Data;
using Forja.DTOs;
using Forja.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forja.Services
{
	public class AnelService
	{
		private readonly AppDbContext _context;

		public AnelService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<LerAnelDTO>> ListarAneisAsync()
		{
			return await _context.Anel_do_poder
				.Select(a => new LerAnelDTO
				{
					Id = a.Id,
					Nome = a.Nome,
					Poder = a.Poder,
					Portador = a.Portador,
					ForjadoPor = a.ForjadoPor,
					Imagem = a.Imagem
				})
				.ToListAsync();
		}

		public async Task<Anel> RegistrarAnelAsync(CriarAnelDTO anelDto)
		{
			// Validações de regra de negócio
			if (!ValidarLimitePorForjador(anelDto.ForjadoPor))
			{
				throw new Exception("Limite de anéis excedido para o tipo de forjador.");
			}

			var anel = new Anel
			{
				Nome = anelDto.Nome,
				Poder = anelDto.Poder,
				Portador = anelDto.Portador,
				ForjadoPor = anelDto.ForjadoPor,
				Imagem = anelDto.Imagem
			};

			_context.Anel_do_poder.Add(anel);
			await _context.SaveChangesAsync();
			return anel;
		}

		public async Task<Anel?> AtualizarAnelAsync(Guid id, EditarAnelDTO anelDto)
		{
			var anel = await _context.Anel_do_poder.FindAsync(id);
			if (anel == null)
			{
				return null;
			}

			anel.Nome = anelDto.Nome;
			anel.Poder = anelDto.Poder;
			anel.Portador = anelDto.Portador;
			anel.ForjadoPor = anelDto.ForjadoPor;
			anel.Imagem = anelDto.Imagem;

			await _context.SaveChangesAsync();
			return anel;
		}

		public async Task<bool> DeletarAnelAsync(Guid id)
		{
			var anel = await _context.Anel_do_poder.FindAsync(id);
			if (anel == null)
			{
				return false;
			}

			_context.Anel_do_poder.Remove(anel);
			await _context.SaveChangesAsync();
			return true;
		}

		private bool ValidarLimitePorForjador(string forjadoPor)
		{
			var tiposValidos = new[] { "elfos", "anões", "homens", "sauron" };

			if (!tiposValidos.Contains(forjadoPor.ToLower()))
			{
				return true;
			}

			var limite = forjadoPor.ToLower() switch
			{
				"elfos" => 3,
				"anões" => 7,
				"homens" => 9,
				"sauron" => 1,
				_ => 0
			};

			var count = _context.Anel_do_poder.Count(a => a.ForjadoPor.ToLower() == forjadoPor.ToLower());
			return count < limite;
		}
	}
}
