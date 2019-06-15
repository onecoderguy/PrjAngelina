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

        [Required(ErrorMessage = "Informe o código da sala, ele será necessário para os alunos se cadastrarem !")]
        public int CodigoSala { get; set; }

        [HiddenInput(DisplayValue = false )]
        public int MateriaId { get; set; }


    }
}