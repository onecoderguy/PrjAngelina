using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngelinaPrj.Models
{
    [Table("Aluno_Sala")]
    public class Aluno_Sala
    {
        [Key]
        public int Aluno_SalaId { get; set; }

        public int UsuarioId { get; set; }

        public int SalaId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Sala Sala { get; set; }
    }
}