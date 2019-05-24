using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngelinaPrj.Models
{
    [Table("Salas")]
    public class Sala
    {
        [Key]
        public int SalaId { get; set; }

        [Required]
        public int Semestre { get; set; }

        [Required]
        public int Situacao { get; set; }
        
        public virtual ICollection<Materia_Sala> Materias_Salas { get; set; }

    }
}