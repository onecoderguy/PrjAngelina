using AngelinaPrj.Models;
using System.Collections.Generic;

namespace AngelinaPrj.ViewModel
{
    public class DetalhesEscolaViewModel
    {
        public Escola Escola { get; set; }

        public string Nome { get; set; }

        public string Cidade { get; set; }

        public List<Curso> Cursos { get; set; }
    }
}