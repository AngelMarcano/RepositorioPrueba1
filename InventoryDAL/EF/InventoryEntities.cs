
using InventoryDAL.Models;
using InventoryDAL.Models.Account;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDAL.EF
{
    public class InventoryEntities : DbContext
    {
        public InventoryEntities() : base("name=InventoryConnection")
        {
            
        }
        private void OnSavingChanges(object sender, EventArgs eventArgs)
        {
            //Sender is of type ObjectContext.  Can get current and original values, and 
            //   cancel /modify the save operation as desired.
            var context = sender as ObjectContext;
            if (context == null) return;
            foreach (ObjectStateEntry item in context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Added))
            {
                //Do something important here
                if ((item.Entity as table_stores) != null)
                {
                    var entity = (table_stores)item.Entity;
                    if (entity.name == "Black")
                    {
                        item.RejectPropertyChanges(nameof(entity.name));
                    }
                }
            }

        }

        private void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
        }

        public virtual DbSet<table_stores> table_stores { get; set; }
        public virtual DbSet<table_articles> table_articles { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<table_stores>()
        //        .HasMany(e => e.Articles);
        //    //.WithRequired(e => e.Car)
        //    //.WillCascadeOnDelete(false);
        //}
    }

    
}
