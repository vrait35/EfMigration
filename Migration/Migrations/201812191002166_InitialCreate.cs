namespace Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCarts",
                c => new
                    {
                        Item_Id = c.Guid(nullable: false),
                        Cart_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Cart_Id })
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_Id, cascadeDelete: true)
                .Index(t => t.Item_Id)
                .Index(t => t.Cart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ItemCarts", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.ItemCarts", "Item_Id", "dbo.Items");
            DropIndex("dbo.ItemCarts", new[] { "Cart_Id" });
            DropIndex("dbo.ItemCarts", new[] { "Item_Id" });
            DropIndex("dbo.Carts", new[] { "User_Id" });
            DropTable("dbo.ItemCarts");
            DropTable("dbo.Users");
            DropTable("dbo.Items");
            DropTable("dbo.Carts");
        }
    }
}
