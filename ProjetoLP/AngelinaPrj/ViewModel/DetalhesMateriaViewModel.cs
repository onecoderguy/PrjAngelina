﻿using AngelinaPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngelinaPrj.ViewModel
{
    public class DetalhesMateriaViewModel
    {
        public Materia Materia { get; set; }

        public Sala Sala { get; set; }

        public List<Materia_Sala> Materia_Salas { get; set; }
    }
}