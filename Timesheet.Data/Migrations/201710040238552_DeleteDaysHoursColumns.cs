namespace Timesheet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDaysHoursColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TsWeekEntries", "Day1Hours");
            DropColumn("dbo.TsWeekEntries", "Day2Hours");
            DropColumn("dbo.TsWeekEntries", "Day3Hours");
            DropColumn("dbo.TsWeekEntries", "Day4Hours");
            DropColumn("dbo.TsWeekEntries", "Day5Hours");
            DropColumn("dbo.TsWeekEntries", "Day6Hours");
            DropColumn("dbo.TsWeekEntries", "Day7Hours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TsWeekEntries", "Day7Hours", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.TsWeekEntries", "Day6Hours", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.TsWeekEntries", "Day5Hours", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.TsWeekEntries", "Day4Hours", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.TsWeekEntries", "Day3Hours", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.TsWeekEntries", "Day2Hours", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.TsWeekEntries", "Day1Hours", c => c.Time(nullable: false, precision: 7));
        }
    }
}
