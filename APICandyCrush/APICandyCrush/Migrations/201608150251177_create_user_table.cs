namespace APICandyCrush.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_user_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.users",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(),
                    email = c.String(),
                    password = c.String()
                })
                .PrimaryKey(t => t.id);
        }
        
        public override void Down()
        {
            DropTable("dbo.users");
        }
    }
}
