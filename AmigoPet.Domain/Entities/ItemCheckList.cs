using System.ComponentModel.DataAnnotations.Schema;

namespace AmigoPet.Domain.Entities
{
    public class ItemChecklist
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string NomeItem { get; set; }

        [Column(TypeName = "NUMBER(1)")]
        public bool Comprado { get; set; }
    }
}