namespace WeatherNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WeatherNotes", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WeatherNotes", "Message", c => c.String());
        }
    }
}
