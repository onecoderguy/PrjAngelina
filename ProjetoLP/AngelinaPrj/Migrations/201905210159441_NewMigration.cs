namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cursos", name: "Escola_EscolaId", newName: "EscolaId");
            RenameIndex(table: "dbo.Cursos", name: "IX_Escola_EscolaId", newName: "IX_EscolaId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cursos", name: "IX_EscolaId", newName: "IX_Escola_EscolaId");
            RenameColumn(table: "dbo.Cursos", name: "EscolaId", newName: "Escola_EscolaId");
        }
    }
}
