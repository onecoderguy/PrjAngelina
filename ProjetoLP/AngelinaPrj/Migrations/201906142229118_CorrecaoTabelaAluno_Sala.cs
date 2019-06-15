namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecaoTabelaAluno_Sala : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Aluno_Sala", "Aluno_UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Aluno_Sala", new[] { "Aluno_UsuarioId" });
            RenameColumn(table: "dbo.Aluno_Sala", name: "Aluno_UsuarioId", newName: "UsuarioId");
            AlterColumn("dbo.Aluno_Sala", "UsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Aluno_Sala", "UsuarioId");
            AddForeignKey("dbo.Aluno_Sala", "UsuarioId", "dbo.Usuarios", "UsuarioId", cascadeDelete: true);
            DropColumn("dbo.Aluno_Sala", "AlunoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno_Sala", "AlunoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Aluno_Sala", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Aluno_Sala", new[] { "UsuarioId" });
            AlterColumn("dbo.Aluno_Sala", "UsuarioId", c => c.Int());
            RenameColumn(table: "dbo.Aluno_Sala", name: "UsuarioId", newName: "Aluno_UsuarioId");
            CreateIndex("dbo.Aluno_Sala", "Aluno_UsuarioId");
            AddForeignKey("dbo.Aluno_Sala", "Aluno_UsuarioId", "dbo.Usuarios", "UsuarioId");
        }
    }
}
