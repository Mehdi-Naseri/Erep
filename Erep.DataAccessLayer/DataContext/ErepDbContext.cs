using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Erep.DataAccessLayer.IUnitOfWork;
using Microsoft.AspNet.Identity.EntityFramework;
using Identity.Models.Models;
using System.Data.Entity;
using Erep.DomainClasses.Models;

namespace Erep.DataAccessLayer.DataContext
{
    public class ErepDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWorkErep
    {
        public ErepDbContext()
            : base("name=ErepConnection")
        {
        }
        public DbSet<Scammer> Scammers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        //public DbSet<GoldPrice> GoldPrices { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<WebsiteVisitor> WebsiteVisitors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //جهت ذخیره داده های فارسی در پایگاه داده اضافه شده است.
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            //جهت ذخیره جداول در شمای "ایدنتیتی" اضافه شده است.
            modelBuilder.HasDefaultSchema("Identity");
            base.OnModelCreating(modelBuilder);
        }

        public static ErepDbContext Create()
        {
            return new ErepDbContext();
        }

        #region IUnitOfWork Members
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        #endregion
    }
}
