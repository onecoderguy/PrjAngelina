namespace AngelinaPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandoValoresTabelaSala : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salas", "Escola", c => c.String(nullable: false));
            AddColumn("dbo.Salas", "Materia", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salas", "Materia");
            DropColumn("dbo.Salas", "Escola");
        }
    }
}
