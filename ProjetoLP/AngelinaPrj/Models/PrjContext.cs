using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngelinaPrj.Models
{
    public class PrjContext : DbContext
    {
        public PrjContext() : base ("prjAngelina")
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}