namespace WeatherNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeatherNotes",
                c => new
                    {
                        WeatherNoteId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.WeatherNoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeatherNotes");
        }
    }
}
