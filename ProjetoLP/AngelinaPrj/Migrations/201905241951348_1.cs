namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Curso_Materia");
            CreateTable(
                "dbo.Materia_Sala",
                c => new
                    {
                        Materia_SalaId = c.Int(nullable: false, identity: true),
                        MateriaId = c.Int(nullable: false),
                        SalaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Materia_SalaId)
                .ForeignKey("dbo.Materias", t => t.MateriaId, cascadeDelete: true)
                .ForeignKey("dbo.Salas", t => t.SalaId, cascadeDelete: true)
                .Index(t => t.MateriaId)
                .Index(t => t.SalaId);
            
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        SalaId = c.Int(nullable: false, identity: true),
                        Semestre = c.Int(nullable: false),
                        Situacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalaId);
            
            AddColumn("dbo.Curso_Materia", "Curso_MateriaId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Materias", "Professor", c => c.String(maxLength: 100));
            AddPrimaryKey("dbo.Curso_Materia", "Curso_MateriaId");
            DropTable("dbo.ConfigSite");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ConfigSite",
                c => new
                    {
                        ConfigId = c.Int(nullable: false, identity: true),
                        NomeProfessor = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ConfigId);
            
            DropForeignKey("dbo.Materia_Sala", "SalaId", "dbo.Salas");
            DropForeignKey("dbo.Materia_Sala", "MateriaId", "dbo.Materias");
            DropIndex("dbo.Materia_Sala", new[] { "SalaId" });
            DropIndex("dbo.Materia_Sala", new[] { "MateriaId" });
            DropPrimaryKey("dbo.Curso_Materia");
            AlterColumn("dbo.Materias", "Professor", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Curso_Materia", "Curso_MateriaId");
            DropTable("dbo.Salas");
            DropTable("dbo.Materia_Sala");
            AddPrimaryKey("dbo.Curso_Materia", new[] { "CursoId", "MateriaId" });
        }
    }
}
