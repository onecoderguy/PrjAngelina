using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngelinaPrj.ViewModel
{
    public class CadastroMateriaViewModel
    {
        [Required(ErrorMessage = "Insira o nome da matéria")]
        [MaxLength(100, ErrorMessage = "Pode conter no máximo 30 caracteres")]
        public string Nome { get; set; }

        [MaxLength(500, ErrorMessage = "Pode conter no máximo 500 caracteres")]
        public string Descricao { get; set; }

        [MaxLength(100, ErrorMessage = "Pode conter no máximo 100 caracteres")]
        public string Professor { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CursoId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int MateriaId { get; set; }
    }
}