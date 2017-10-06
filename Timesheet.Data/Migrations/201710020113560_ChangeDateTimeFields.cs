namespace Timesheet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TsWeekTemplates", "StartTime", c => c.DateTime());
            AlterColumn("dbo.TsWeekTemplates", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TsWeekTemplates", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TsWeekTemplates", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
