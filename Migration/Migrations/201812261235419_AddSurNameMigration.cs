namespace Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSurNameMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "SurName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "SurName");
        }
    }
}
