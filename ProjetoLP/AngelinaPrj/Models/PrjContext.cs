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

        public DbSet<Sala> Salas { get; set; }

        public DbSet<Materia_Sala> Materias_Salas { get; set; }

        public DbSet<Curso_Materia> Cursos_Materias { get; set; }

        public DbSet<Aluno_Sala> Alunos_Sala { get; set; }

        public DbSet<Material> Materiais { get; set; }

        public DbSet<Exercicio> Exercicios { get; set; }
    }
}