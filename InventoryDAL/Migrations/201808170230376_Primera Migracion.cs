namespace InventoryDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.table_articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 100),
                        description = c.String(maxLength: 300),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        total_in_shelf = c.Int(nullable: false),
                        total_in_vault = c.Int(nullable: false),
                        store_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.table_stores", t => t.store_id, cascadeDelete: true)
                .Index(t => t.store_id);
            
            CreateTable(
                "dbo.table_stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        address = c.String(nullable: false, maxLength: 300),
                        name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.table_articles", "store_id", "dbo.table_stores");
            DropIndex("dbo.table_articles", new[] { "store_id" });
            DropTable("dbo.table_stores");
            DropTable("dbo.table_articles");
        }
    }
}
