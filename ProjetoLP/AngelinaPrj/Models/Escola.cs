using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngelinaPrj.Models
{
    [Table("Escolas")]
    public class Escola
    {
        public int EscolaId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(70)]
        public string Cidade { get; set; }
    }
}