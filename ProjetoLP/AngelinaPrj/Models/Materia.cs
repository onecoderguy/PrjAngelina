using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngelinaPrj.Models
{
    [Table("Materias")]
    public class Materia
    {
        [Key]
        public int MateriaId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }
        
        [MaxLength(500)]
        public string Descricao { get; set; }
        
        [MaxLength(100)]
        public string Professor { get; set; }

        [Required]
        public int CursoId { get; set; }

        public virtual ICollection<Curso_Materia> Curso_Materias { get; set; }

        public virtual ICollection<Materia_Sala> Materia_Salas { get; set; }
    }
}