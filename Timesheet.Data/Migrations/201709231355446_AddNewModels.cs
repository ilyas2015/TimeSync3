namespace Timesheet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TsDocumentEntities",
                c => new
                    {
                        TsDocumentEntityId = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(),
                        UserId = c.String(nullable: false),
                        DocGuid = c.Guid(nullable: false),
                        SavedName = c.String(),
                        SystemDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TsDocumentEntityId);
            
            CreateTable(
                "dbo.TsEntries",
                c => new
                    {
                        TsEntryId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        TotalHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TsEntryId);
            
            CreateTable(
                "dbo.TsWeekEntries",
                c => new
                    {
                        TsWeekEntryId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TotalHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.String(nullable: false),
                        TsEntryId = c.Int(nullable: false),
                        Day1 = c.DateTime(),
                        Day1Hours = c.Time(nullable: false, precision: 7),
                        Day1StartTime = c.DateTime(),
                        Day1EndTime = c.DateTime(),
                        Day2 = c.DateTime(),
                        Day2Hours = c.Time(nullable: false, precision: 7),
                        Day2StartTime = c.DateTime(),
                        Day2EndTime = c.DateTime(),
                        Day3 = c.DateTime(),
                        Day3Hours = c.Time(nullable: false, precision: 7),
                        Day3StartTime = c.DateTime(),
                        Day3EndTime = c.DateTime(),
                        Day4 = c.DateTime(),
                        Day4Hours = c.Time(nullable: false, precision: 7),
                        Day4StartTime = c.DateTime(),
                        Day4EndTime = c.DateTime(),
                        Day5 = c.DateTime(),
                        Day5Hours = c.Time(nullable: false, precision: 7),
                        Day5StartTime = c.DateTime(),
                        Day5EndTime = c.DateTime(),
                        Day6 = c.DateTime(),
                        Day6Hours = c.Time(nullable: false, precision: 7),
                        Day6StartTime = c.DateTime(),
                        Day6EndTime = c.DateTime(),
                        Day7 = c.DateTime(),
                        Day7Hours = c.Time(nullable: false, precision: 7),
                        Day7StartTime = c.DateTime(),
                        Day7EndTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.TsWeekEntryId)
                .ForeignKey("dbo.TsEntries", t => t.TsEntryId, cascadeDelete: true)
                .Index(t => t.TsEntryId);
            
            CreateTable(
                "dbo.TsSettings",
                c => new
                    {
                        TsSettingId = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(),
                        BusinessAddress = c.String(),
                        BusinessHST = c.String(),
                        InvoiceToCompanyName = c.String(),
                        InvoiceToCompanyAddress = c.String(),
                        InvoiceProject = c.String(),
                        HourRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HST = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastInvoiceNumber = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.TsSettingId);
            
            CreateTable(
                "dbo.TsWeekTemplates",
                c => new
                    {
                        TsWeekTemplateId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        TemplateName = c.String(),
                        HoursInDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FillDay1 = c.Boolean(nullable: false),
                        FillDay2 = c.Boolean(nullable: false),
                        FillDay3 = c.Boolean(nullable: false),
                        FillDay4 = c.Boolean(nullable: false),
                        FillDay5 = c.Boolean(nullable: false),
                        FillDay6 = c.Boolean(nullable: false),
                        FillDay7 = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TsWeekTemplateId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TsWeekTemplates", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TsWeekEntries", "TsEntryId", "dbo.TsEntries");
            DropIndex("dbo.TsWeekTemplates", new[] { "ApplicationUserId" });
            DropIndex("dbo.TsWeekEntries", new[] { "TsEntryId" });
            DropTable("dbo.TsWeekTemplates");
            DropTable("dbo.TsSettings");
            DropTable("dbo.TsWeekEntries");
            DropTable("dbo.TsEntries");
            DropTable("dbo.TsDocumentEntities");
        }
    }
}
