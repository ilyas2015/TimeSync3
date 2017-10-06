namespace Timesheet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDaysHoursColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TsWeekEntries", "Day1Hours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TsWeekEntries", "Day2Hours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TsWeekEntries", "Day3Hours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TsWeekEntries", "Day4Hours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TsWeekEntries", "Day5Hours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TsWeekEntries", "Day6Hours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TsWeekEntries", "Day7Hours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TsWeekEntries", "Day7Hours");
            DropColumn("dbo.TsWeekEntries", "Day6Hours");
            DropColumn("dbo.TsWeekEntries", "Day5Hours");
            DropColumn("dbo.TsWeekEntries", "Day4Hours");
            DropColumn("dbo.TsWeekEntries", "Day3Hours");
            DropColumn("dbo.TsWeekEntries", "Day2Hours");
            DropColumn("dbo.TsWeekEntries", "Day1Hours");
        }
    }
}
