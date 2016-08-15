namespace APICandyCrush.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_game_user_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.game",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        score = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.game");
        }
    }
}
