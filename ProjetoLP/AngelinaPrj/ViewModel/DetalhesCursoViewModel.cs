using AngelinaPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngelinaPrj.ViewModel
{
    public class DetalhesCursoViewModel
    {
        public Curso Curso { get; set; }

        public Escola Escola { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public List<Materia> Materias { get; set; }
    }
}