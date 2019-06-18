using AngelinaPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngelinaPrj.ViewModel
{
    public class DetalhesSalaViewModel
    {
        public Sala Sala { get; set; }

        public string Escola { get; set; }

        public string Materia { get; set; }

        public string Periodo { get; set; }

        public bool Situacao { get; set; }

        public List<Material> Materiais { get; set; }
    }
}