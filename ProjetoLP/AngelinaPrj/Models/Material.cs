using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngelinaPrj.Models
{
    [Table("Materiais")]
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Assunto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        public string Descrição { get; set; }

        public string Arquivo { get; set; }

        public virtual Sala Sala { get; set; }
    }
}