namespace Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFewThingsToArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Article", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Article", "Price");
        }
    }
}
