using System.Data.Entity;

namespace AngelinaPrj.Models
{
    public class PrjContext : DbContext
    {
        public PrjContext() : base ("prjAngelina")
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Escola> Escolas { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Materia> Materias { get; set; }
    }
}