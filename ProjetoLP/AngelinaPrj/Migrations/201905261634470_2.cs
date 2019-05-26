namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salas", "Periodo", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Salas", "Situacao", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Salas", "Situacao", c => c.Int(nullable: false));
            DropColumn("dbo.Salas", "Periodo");
        }
    }
}
