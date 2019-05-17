namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PadronizandoClasseUsuarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "DataNascimento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Usuarios", "Email", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Usuarios", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Login", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Usuarios", "Email");
            DropColumn("dbo.Usuarios", "DataNascimento");
        }
    }
}
