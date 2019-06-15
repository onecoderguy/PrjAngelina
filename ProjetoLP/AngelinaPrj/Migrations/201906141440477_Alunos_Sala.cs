namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alunos_Sala : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno_Sala",
                c => new
                    {
                        Aluno_SalaId = c.Int(nullable: false, identity: true),
                        AlunoId = c.Int(nullable: false),
                        SalaId = c.Int(nullable: false),
                        Aluno_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.Aluno_SalaId)
                .ForeignKey("dbo.Usuarios", t => t.Aluno_UsuarioId)
                .ForeignKey("dbo.Salas", t => t.SalaId, cascadeDelete: true)
                .Index(t => t.SalaId)
                .Index(t => t.Aluno_UsuarioId);
            
            AddColumn("dbo.Salas", "CodigoSala", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluno_Sala", "SalaId", "dbo.Salas");
            DropForeignKey("dbo.Aluno_Sala", "Aluno_UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Aluno_Sala", new[] { "Aluno_UsuarioId" });
            DropIndex("dbo.Aluno_Sala", new[] { "SalaId" });
            DropColumn("dbo.Salas", "CodigoSala");
            DropTable("dbo.Aluno_Sala");
        }
    }
}
