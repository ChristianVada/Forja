namespace Forja.src
{
    public enum Forjador
    {
        Elfos = 1,
        Anoes = 2,
        Homens = 3,
        Sauron = 4
    }
    public class AnelEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Poder { get; set; }
        public string Portador { get; set; }
        public Forjador ForjadoPor { get; set; }
        public string Imagem { get; set; }
    }
}
