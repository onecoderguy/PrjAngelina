using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngelinaPrj.Models
{
    [Table("Salas")]
    public class Sala
    {
        public Sala()
        {
            Materiais = new HashSet<Material>();
        }

        [Key]
        public int SalaId { get; set; }

        [Required]
        public int Semestre { get; set; }

        [Required]
        [MaxLength(10)]
        public string Periodo { get; set; }

        [Required]
        public int CodigoSala { get; set; }

        [Required]
        public string Escola { get; set; }

        [Required]
        public string Materia { get; set; }

        [Required]
        public bool Situacao { get; set; }
        
        public virtual ICollection<Materia_Sala> Materias_Salas { get; set; }

        public virtual ICollection<Aluno_Sala> Alunos_Sala { get; set; }

        public virtual ICollection<Material> Materiais { get; set; }
    }
}