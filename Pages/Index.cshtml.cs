using Forja.src;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Forja.src.AnelService;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAnelService _anelService;

        public IndexModel(IAnelService anelService)
        {
            _anelService = anelService;
        }

        public IEnumerable<AnelEntity> Aneis { get; set; }

        [BindProperty]
        public AnelEntity NovoAnel { get; set; }

        [BindProperty]
        public int Id { get; set; }

        public void OnGet()
        {
            Aneis = _anelService.Listar();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _anelService.Criar(NovoAnel);
                return RedirectToPage(); 
            }
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            _anelService.Deletar(id);
            return RedirectToPage();
        }

        public IActionResult OnPostEdit()
        {
            if (ModelState.IsValid)
            {
                var anel = _anelService.Listar().FirstOrDefault(a => a.Id == Id);
                if (anel != null)
                {
                    anel.Nome = NovoAnel.Nome;
                    anel.Poder = NovoAnel.Poder;
                    anel.Portador = NovoAnel.Portador;
                    anel.ForjadoPor = NovoAnel.ForjadoPor;
                    _anelService.Atualizar(Id, anel); 
                }
                return RedirectToPage(); 
            }
            return Page();
        }
    }
}
