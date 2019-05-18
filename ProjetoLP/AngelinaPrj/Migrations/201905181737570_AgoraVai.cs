namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgoraVai : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(nullable: false, maxLength: 500),
                        Escola_EscolaId = c.Int(),
                        Escola_EscolaId1 = c.Int(nullable: false),
                        Materia_MateriaId = c.Int(),
                    })
                .PrimaryKey(t => t.CursoId)
                .ForeignKey("dbo.Escolas", t => t.Escola_EscolaId)
                .ForeignKey("dbo.Escolas", t => t.Escola_EscolaId1, cascadeDelete: true)
                .ForeignKey("dbo.Materias", t => t.Materia_MateriaId)
                .Index(t => t.Escola_EscolaId)
                .Index(t => t.Escola_EscolaId1)
                .Index(t => t.Materia_MateriaId);
            
            CreateTable(
                "dbo.Escolas",
                c => new
                    {
                        EscolaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                        Cidade = c.String(nullable: false, maxLength: 70),
                        Curso_CursoId = c.Int(),
                    })
                .PrimaryKey(t => t.EscolaId)
                .ForeignKey("dbo.Cursos", t => t.Curso_CursoId)
                .Index(t => t.Curso_CursoId);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        MateriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Descricao = c.String(maxLength: 500),
                        Professor = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.MateriaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Senha = c.String(nullable: false, maxLength: 100),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cursos", "Materia_MateriaId", "dbo.Materias");
            DropForeignKey("dbo.Escolas", "Curso_CursoId", "dbo.Cursos");
            DropForeignKey("dbo.Cursos", "Escola_EscolaId1", "dbo.Escolas");
            DropForeignKey("dbo.Cursos", "Escola_EscolaId", "dbo.Escolas");
            DropIndex("dbo.Escolas", new[] { "Curso_CursoId" });
            DropIndex("dbo.Cursos", new[] { "Materia_MateriaId" });
            DropIndex("dbo.Cursos", new[] { "Escola_EscolaId1" });
            DropIndex("dbo.Cursos", new[] { "Escola_EscolaId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Materias");
            DropTable("dbo.Escolas");
            DropTable("dbo.Cursos");
        }
    }
}
