namespace Forja.src
{
    public interface IAnelService
    {
        IEnumerable<AnelEntity> Listar();
        AnelEntity Criar(AnelEntity anel);
        AnelEntity Atualizar(int id, AnelEntity anel);
        void Deletar(int id);
    }
}
