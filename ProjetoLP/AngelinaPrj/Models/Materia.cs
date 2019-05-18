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
        public Materia()
        {
            Cursos = new HashSet<Curso>();
        }
        [Key]
        public int MateriaId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }
        
        [MaxLength(500)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(100)]
        public string Professor { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}