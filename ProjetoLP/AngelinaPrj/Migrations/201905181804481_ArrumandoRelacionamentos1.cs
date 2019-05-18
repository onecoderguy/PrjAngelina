namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArrumandoRelacionamentos1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cursos", "Materia_MateriaId", "dbo.Materias");
            DropIndex("dbo.Cursos", new[] { "Materia_MateriaId" });
            CreateTable(
                "dbo.MateriaCursoes",
                c => new
                    {
                        Materia_MateriaId = c.Int(nullable: false),
                        Curso_CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Materia_MateriaId, t.Curso_CursoId })
                .ForeignKey("dbo.Materias", t => t.Materia_MateriaId, cascadeDelete: true)
                .ForeignKey("dbo.Cursos", t => t.Curso_CursoId, cascadeDelete: true)
                .Index(t => t.Materia_MateriaId)
                .Index(t => t.Curso_CursoId);
            
            DropColumn("dbo.Cursos", "Materia_MateriaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cursos", "Materia_MateriaId", c => c.Int());
            DropForeignKey("dbo.MateriaCursoes", "Curso_CursoId", "dbo.Cursos");
            DropForeignKey("dbo.MateriaCursoes", "Materia_MateriaId", "dbo.Materias");
            DropIndex("dbo.MateriaCursoes", new[] { "Curso_CursoId" });
            DropIndex("dbo.MateriaCursoes", new[] { "Materia_MateriaId" });
            DropTable("dbo.MateriaCursoes");
            CreateIndex("dbo.Cursos", "Materia_MateriaId");
            AddForeignKey("dbo.Cursos", "Materia_MateriaId", "dbo.Materias", "MateriaId");
        }
    }
}
