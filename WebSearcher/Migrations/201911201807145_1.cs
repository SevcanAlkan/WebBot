﻿namespace WebSearcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SearchPoints", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SearchPoints", "Name");
        }
    }
}
