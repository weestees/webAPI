namespace GestorColecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescripcionYPeso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fosils", "Descripcion", c => c.String(nullable: false));
            AddColumn("dbo.Fosils", "Peso", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Rocas", "Descripcion", c => c.String(nullable: false));
            AddColumn("dbo.Rocas", "Peso", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Fosils", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Fosils", "Especie", c => c.String(nullable: false));
            AlterColumn("dbo.Fosils", "Periodo", c => c.String(nullable: false));
            AlterColumn("dbo.Rocas", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Rocas", "Tipo", c => c.String(nullable: false));
            AlterColumn("dbo.Rocas", "Ubicacion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rocas", "Ubicacion", c => c.String());
            AlterColumn("dbo.Rocas", "Tipo", c => c.String());
            AlterColumn("dbo.Rocas", "Nombre", c => c.String());
            AlterColumn("dbo.Fosils", "Periodo", c => c.String());
            AlterColumn("dbo.Fosils", "Especie", c => c.String());
            AlterColumn("dbo.Fosils", "Nombre", c => c.String());
            DropColumn("dbo.Rocas", "Peso");
            DropColumn("dbo.Rocas", "Descripcion");
            DropColumn("dbo.Fosils", "Peso");
            DropColumn("dbo.Fosils", "Descripcion");
        }
    }
}
