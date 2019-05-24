using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngelinaPrj.Models
{
    [Table("Curso_Materia")]
    public class Curso_Materia
    {
        [Key]
        public int Curso_MateriaId { get; set; }

        public int  CursoId { get; set; }

        public int MateriaId { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Materia Materias { get; set; }
    }
}