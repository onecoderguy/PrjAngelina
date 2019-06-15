using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace AngelinaPrj.Models
{
    [Table("Cursos")]
    public class Curso
    {
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

        public virtual ICollection<Curso_Materia> Curso_Materias { get; set; }
    }
}