using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngelinaPrj.Models
{
    [Table("Escolas")]
    public class Escola
    {
        public Escola()
        {
            Cursos = new HashSet<Curso>();
        }

        [Key]
        public int EscolaId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(70)]
        public string Cidade { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}