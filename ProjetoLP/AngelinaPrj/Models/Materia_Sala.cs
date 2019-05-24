using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngelinaPrj.Models
{
    [Table("Materia_Sala")]
    public class Materia_Sala
    {
        [Key]
        public int Materia_SalaId { get; set; }
        
        public int MateriaId { get; set; }
        
        public int SalaId { get; set; }

        public virtual Materia Materia { get; set; }

        public virtual Sala Salas { get; set; }
}
}