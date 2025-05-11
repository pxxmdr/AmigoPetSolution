namespace AmigoPet.Domain.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; } 
        public string Raca { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}