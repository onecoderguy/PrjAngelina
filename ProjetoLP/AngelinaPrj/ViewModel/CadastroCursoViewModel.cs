using AngelinaPrj.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AngelinaPrj.ViewModel
{
    public class CadastroCursoViewModel
    {
        [Required(ErrorMessage = "Insira o nome do curso")]
        [MaxLength(100, ErrorMessage = "Pode conter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [MaxLength(500, ErrorMessage = "Pode conter no máximo 500 caracteres")]
        public string Descricao { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public int Escola { get; set; }
    }
}