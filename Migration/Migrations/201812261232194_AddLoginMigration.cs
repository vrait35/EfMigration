namespace Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoginMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Login", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "Login");
        }
    }
}
