namespace InventoryDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "UserInfoes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserInfoes", newName: "Users");
        }
    }
}
