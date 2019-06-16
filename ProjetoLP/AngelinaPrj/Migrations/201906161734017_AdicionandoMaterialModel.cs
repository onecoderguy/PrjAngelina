namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoMaterialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materiais",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Assunto = c.String(nullable: false, maxLength: 150),
                        Data = c.DateTime(nullable: false),
                        Descrição = c.String(nullable: false),
                        Arquivo = c.String(),
                        Sala_SalaId = c.Int(),
                    })
                .PrimaryKey(t => t.MaterialId)
                .ForeignKey("dbo.Salas", t => t.Sala_SalaId)
                .Index(t => t.Sala_SalaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materiais", "Sala_SalaId", "dbo.Salas");
            DropIndex("dbo.Materiais", new[] { "Sala_SalaId" });
            DropTable("dbo.Materiais");
        }
    }
}
