namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArrumandoTabelaCurso : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cursos", "Escola_EscolaId", "dbo.Escolas");
            DropForeignKey("dbo.Cursos", "Escola_EscolaId1", "dbo.Escolas");
            DropForeignKey("dbo.Escolas", "Curso_CursoId", "dbo.Cursos");
            DropIndex("dbo.Cursos", new[] { "Escola_EscolaId" });
            DropIndex("dbo.Cursos", new[] { "Escola_EscolaId1" });
            DropIndex("dbo.Escolas", new[] { "Curso_CursoId" });
            CreateTable(
                "dbo.EscolaCursoes",
                c => new
                    {
                        Escola_EscolaId = c.Int(nullable: false),
                        Curso_CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Escola_EscolaId, t.Curso_CursoId })
                .ForeignKey("dbo.Escolas", t => t.Escola_EscolaId, cascadeDelete: true)
                .ForeignKey("dbo.Cursos", t => t.Curso_CursoId, cascadeDelete: true)
                .Index(t => t.Escola_EscolaId)
                .Index(t => t.Curso_CursoId);
            
            DropColumn("dbo.Cursos", "Escola_EscolaId");
            DropColumn("dbo.Cursos", "Escola_EscolaId1");
            DropColumn("dbo.Escolas", "Curso_CursoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Escolas", "Curso_CursoId", c => c.Int());
            AddColumn("dbo.Cursos", "Escola_EscolaId1", c => c.Int(nullable: false));
            AddColumn("dbo.Cursos", "Escola_EscolaId", c => c.Int());
            DropForeignKey("dbo.EscolaCursoes", "Curso_CursoId", "dbo.Cursos");
            DropForeignKey("dbo.EscolaCursoes", "Escola_EscolaId", "dbo.Escolas");
            DropIndex("dbo.EscolaCursoes", new[] { "Curso_CursoId" });
            DropIndex("dbo.EscolaCursoes", new[] { "Escola_EscolaId" });
            DropTable("dbo.EscolaCursoes");
            CreateIndex("dbo.Escolas", "Curso_CursoId");
            CreateIndex("dbo.Cursos", "Escola_EscolaId1");
            CreateIndex("dbo.Cursos", "Escola_EscolaId");
            AddForeignKey("dbo.Escolas", "Curso_CursoId", "dbo.Cursos", "CursoId");
            AddForeignKey("dbo.Cursos", "Escola_EscolaId1", "dbo.Escolas", "EscolaId", cascadeDelete: true);
            AddForeignKey("dbo.Cursos", "Escola_EscolaId", "dbo.Escolas", "EscolaId");
        }
    }
}
