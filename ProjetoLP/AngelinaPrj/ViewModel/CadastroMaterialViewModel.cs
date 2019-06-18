using AngelinaPrj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngelinaPrj.ViewModel
{
    public class CadastroMaterialViewModel
    {
        [Required(ErrorMessage = "Insira uma introdução sobre material.")]
        [MaxLength(75, ErrorMessage = "Máximo 75 caracteres.")]
        public string Resumo { get; set; }

        [Required(ErrorMessage = "Insira os tópicos que serão abordados.")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres.")]
        public string Assunto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Insira o material por escrito aqui")]
        public string Descricao { get; set; }

        [Display(Name = "Arquivo de apoio")]
        public string Arquivo { get; set; }

        public int SalaId { get; set; }
    }
}