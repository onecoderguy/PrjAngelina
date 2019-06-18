namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercicio", "Material_MaterialId", "dbo.Materiais");
            DropIndex("dbo.Exercicio", new[] { "Material_MaterialId" });
            RenameColumn(table: "dbo.Exercicio", name: "Material_MaterialId", newName: "MaterialId");
            AlterColumn("dbo.Exercicio", "MaterialId", c => c.Int(nullable: false));
            CreateIndex("dbo.Exercicio", "MaterialId");
            AddForeignKey("dbo.Exercicio", "MaterialId", "dbo.Materiais", "MaterialId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercicio", "MaterialId", "dbo.Materiais");
            DropIndex("dbo.Exercicio", new[] { "MaterialId" });
            AlterColumn("dbo.Exercicio", "MaterialId", c => c.Int());
            RenameColumn(table: "dbo.Exercicio", name: "MaterialId", newName: "Material_MaterialId");
            CreateIndex("dbo.Exercicio", "Material_MaterialId");
            AddForeignKey("dbo.Exercicio", "Material_MaterialId", "dbo.Materiais", "MaterialId");
        }
    }
}
