using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Timesheet.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<TsWeekTemplate> TsWeekTemplates { get; set; }
        public IDbSet<TsEntry> TsEntries { get; set; }
        public IDbSet<TsWeekEntry> TsWeekEntriesEntries { get; set; }
        public IDbSet<TsDocumentEntity> TsDocumentEntries { get; set; }
        public IDbSet<TsSetting> TsSettings { get; set; }
        //public IDbSet<ApplicationUser> AccountUsers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}