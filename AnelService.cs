namespace WebApplication2
{
    public class AnelService : IAnelService
    {
        private readonly AnelDbContext _context;

        public AnelService(AnelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AnelEntity> Listar() => _context.Aneis.ToList();

        public AnelEntity Criar(AnelEntity anel)
        {
            var quantidade = _context.Aneis.Count(a => a.ForjadoPor == anel.ForjadoPor);
            if ((anel.ForjadoPor == Forjador.Elfos && quantidade >= 3) ||
                (anel.ForjadoPor == Forjador.Anoes && quantidade >= 7) ||
                (anel.ForjadoPor == Forjador.Homens && quantidade >= 9) ||
                (anel.ForjadoPor == Forjador.Sauron && quantidade >= 1))
            {
                throw new System.Exception("Limite de anéis para " + anel.ForjadoPor + " atingido.");
            }

            _context.Aneis.Add(anel);
            _context.SaveChanges();
            return anel;
        }

        public AnelEntity Atualizar(int id, AnelEntity anel)
        {
            var anelExistente = _context.Aneis.Find(anel.Id);
            if (anelExistente == null) throw new System.Exception("Anel não encontrado.");

            anelExistente.Nome = anel.Nome;
            anelExistente.Poder = anel.Poder;
            anelExistente.Portador = anel.Portador;
            anelExistente.ForjadoPor = anel.ForjadoPor;
            anelExistente.Imagem = anel.Imagem;

            _context.SaveChanges();
            return anelExistente;
        }

        public void Deletar(int id)
        {
            var anel = _context.Aneis.Find(id);
            if (anel == null) throw new System.Exception("Anel não encontrado.");

            _context.Aneis.Remove(anel);
            _context.SaveChanges();
        }
    }
}
