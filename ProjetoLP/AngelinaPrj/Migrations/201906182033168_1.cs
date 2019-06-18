namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercicio", "Material_MaterialId", c => c.Int());
            CreateIndex("dbo.Exercicio", "Material_MaterialId");
            AddForeignKey("dbo.Exercicio", "Material_MaterialId", "dbo.Materiais", "MaterialId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercicio", "Material_MaterialId", "dbo.Materiais");
            DropIndex("dbo.Exercicio", new[] { "Material_MaterialId" });
            DropColumn("dbo.Exercicio", "Material_MaterialId");
        }
    }
}
