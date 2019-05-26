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
        [MaxLength(10, ErrorMessage = "Pode conter no máximo 10 caracteres")]
        public string Periodo { get; set; }

        [Required]
        public bool Situacao { get; set; }
        
        public virtual ICollection<Materia_Sala> Materias_Salas { get; set; }

    }
}