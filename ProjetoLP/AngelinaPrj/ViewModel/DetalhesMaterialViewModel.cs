using AngelinaPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngelinaPrj.ViewModel
{
    public class DetalhesMaterialViewModel
    {
        public Material Material { get; set; }

        public string Resumo { get; set; }
        
        public string Assunto { get; set; }

        public DateTime Data { get; set; }

        public string Descricao { get; set; }

        public string Arquivo { get; set; }

        public List<Exercicio> Exercicios { get; set; }
    }
}