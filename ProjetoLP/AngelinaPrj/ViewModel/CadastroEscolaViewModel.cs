using AngelinaPrj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngelinaPrj.ViewModel
{
    public class CadastroEscolaViewModel
    {
        public CadastroEscolaViewModel()
        {
            Cursos = new HashSet<Curso>();
        }

        [Required(ErrorMessage = "Insira o nome da escola")]
        [MaxLength(150,ErrorMessage = "Pode conter no máximo 150 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira a cidade da escola")]
        [MaxLength(70, ErrorMessage = "Pode conter no máximo 70 caracteres")]
        public string Cidade { get; set; }
            
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}