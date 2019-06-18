using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngelinaPrj.Models
{
    [Table("Materiais")]
    public class Material
    {
        public Material()
        {
            Exercicios = new HashSet<Exercicio>();
        }

        [Key]
        public int MaterialId { get; set; }

        [Required]
        [MaxLength(75)]
        public string Resumo { get; set; }

        [Required]
        [MaxLength(150)]
        public string Assunto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        public string Descricao { get; set; }

        public string Arquivo { get; set; }

        [HiddenInput]
        public int SalaId { get; set; }

        public virtual Sala Sala { get; set; }

        public virtual ICollection<Exercicio> Exercicios { get; set; }
    }
}