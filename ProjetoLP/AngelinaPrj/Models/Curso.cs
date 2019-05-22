using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngelinaPrj.Models
{
    [Table("Cursos")]
    public class Curso
    {
        public Curso()
        {
            Materias = new HashSet<Materia>();
        }

        [Key]
        public int CursoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }

        [HiddenInput]
        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }

        public virtual ICollection<Materia> Materias { get; set; }
    }
}