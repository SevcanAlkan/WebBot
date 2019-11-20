namespace WebSearcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SearchPoints",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WebSite = c.Int(nullable: false),
                        CheckDate = c.DateTime(),
                        UrlParameters = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SearchPoints");
        }
    }
}
