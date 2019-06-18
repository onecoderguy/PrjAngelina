using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngelinaPrj.Models
{
    [Table("Exercicio")]
    public class Exercicio
    {

        [Key]
        public int ExercicioId { get; set; }

        [Required]
        public string Proposta { get; set; }

        
        public string Arquivo { get; set; }

        [Required]
        public DateTime DataDeEntrega { get; set; }

        public int MaterialId { get; set; }

        public virtual Material Material { get; set; }
    }
}