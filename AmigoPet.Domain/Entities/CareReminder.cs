using System.ComponentModel.DataAnnotations.Schema;

namespace AmigoPet.Domain.Entities
{
    public class CareReminder
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string Tipo { get; set; }
        public DateTime DataAgendada { get; set; }

        [Column(TypeName = "NUMBER(1)")]
        public bool Concluido { get; set; }
    }
}