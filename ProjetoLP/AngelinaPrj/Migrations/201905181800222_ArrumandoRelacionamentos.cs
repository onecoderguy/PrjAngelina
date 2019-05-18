namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArrumandoRelacionamentos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EscolaCursoes", "Escola_EscolaId", "dbo.Escolas");
            DropForeignKey("dbo.EscolaCursoes", "Curso_CursoId", "dbo.Cursos");
            DropIndex("dbo.EscolaCursoes", new[] { "Escola_EscolaId" });
            DropIndex("dbo.EscolaCursoes", new[] { "Curso_CursoId" });
            AddColumn("dbo.Cursos", "Escola_EscolaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cursos", "Escola_EscolaId");
            AddForeignKey("dbo.Cursos", "Escola_EscolaId", "dbo.Escolas", "EscolaId", cascadeDelete: true);
            DropTable("dbo.EscolaCursoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EscolaCursoes",
                c => new
                    {
                        Escola_EscolaId = c.Int(nullable: false),
                        Curso_CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Escola_EscolaId, t.Curso_CursoId });
            
            DropForeignKey("dbo.Cursos", "Escola_EscolaId", "dbo.Escolas");
            DropIndex("dbo.Cursos", new[] { "Escola_EscolaId" });
            DropColumn("dbo.Cursos", "Escola_EscolaId");
            CreateIndex("dbo.EscolaCursoes", "Curso_CursoId");
            CreateIndex("dbo.EscolaCursoes", "Escola_EscolaId");
            AddForeignKey("dbo.EscolaCursoes", "Curso_CursoId", "dbo.Cursos", "CursoId", cascadeDelete: true);
            AddForeignKey("dbo.EscolaCursoes", "Escola_EscolaId", "dbo.Escolas", "EscolaId", cascadeDelete: true);
        }
    }
}
