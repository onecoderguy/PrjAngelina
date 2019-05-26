using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AngelinaPrj.ViewModel
{
    public class CadastroSalaViewModel
    {
        [Required(ErrorMessage = "Informe o semestre da sala" )]
        public int Semestre { get; set; }

        [Required(ErrorMessage = "Informe a situação da sala" )]
        public bool Situacao { get; set; }

        [Required(ErrorMessage = "Informe o período da sala")]
        public string Periodo { get; set; }

        [HiddenInput(DisplayValue = false )]
        public int MateriaId { get; set; }


    }
}