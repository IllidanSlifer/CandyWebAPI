namespace APICandyCrush.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_UserPartidas_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPartidas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PartidaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.game", t => t.PartidaID, cascadeDelete: true)
                .ForeignKey("dbo.users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.PartidaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPartidas", "UserID", "dbo.users");
            DropForeignKey("dbo.UserPartidas", "PartidaID", "dbo.game");
            DropIndex("dbo.UserPartidas", new[] { "PartidaID" });
            DropIndex("dbo.UserPartidas", new[] { "UserID" });
            DropTable("dbo.UserPartidas");
        }
    }
}
