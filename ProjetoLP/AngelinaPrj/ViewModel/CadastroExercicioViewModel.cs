using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngelinaPrj.ViewModel
{
    public class CadastroExercicioViewModel
    {
        [Required(ErrorMessage = "Insira a proposta do exerício")]
        public string Proposta { get; set; }

        public string Arquivo { get; set; }

        [Required(ErrorMessage = "Insira a data limite para entrega do exercício")]
        [DataType(DataType.Date)]
        public DateTime DataDeEntrega { get; set; }

        [Required]
        public int MaterialId { get; set; }
    }
}