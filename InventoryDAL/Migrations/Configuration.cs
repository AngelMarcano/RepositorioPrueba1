namespace InventoryDAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using InventoryDAL.Models;
  

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryDAL.EF.InventoryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InventoryDAL.EF.InventoryEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var stores = new List<table_stores>{
                new table_stores{Id=1,name= "Principal", address="Distrito capital, Calle independencia"},
                new table_stores{Id=2,name= "Norte", address="Distrito capital, Zona norte"},
                new table_stores{Id=3,name= "Sur", address="Distrito capital, Zona Sur"}
            };

            stores.ForEach(s => context.table_stores.Add(s));
            context.SaveChanges();

            var articules = new List<table_articles>
            {
                new table_articles{table_stores=(table_stores)stores[0],name="Addidas",price=35,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[0],name="Bloch",price=20,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[0],name="Chicco",price=20,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[0],name="Diesel",price=25,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[0],name="Ecco",price=45,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[0],name="Flogg",price=15,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[0],name="Hummel",price=25,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[0],name="Kappa",price=35,total_in_shelf=10,total_in_vault=50},
            };

            articules.ForEach(s => context.table_articles.Add(s));
            context.SaveChanges();

            var articules2 = new List<table_articles>
            {
                new table_articles{table_stores=(table_stores)stores[1],name="Addidas",price=35,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[1],name="Bloch",price=20,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[1],name="Chicco",price=20,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[1],name="Diesel",price=25,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[1],name="Ecco",price=45,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[1],name="Flogg",price=15,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[1],name="Hummel",price=25,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[1],name="Kappa",price=35,total_in_shelf=10,total_in_vault=50},
            };

            articules2.ForEach(s => context.table_articles.Add(s));
            context.SaveChanges();

            var articules3 = new List<table_articles>
            {
                new table_articles{table_stores=(table_stores)stores[2],name="Addidas",price=35,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[2],name="Bloch",price=20,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[2],name="Chicco",price=20,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[2],name="Diesel",price=25,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[2],name="Ecco",price=45,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[2],name="Flogg",price=15,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[2],name="Hummel",price=25,total_in_shelf=10,total_in_vault=50},
                new table_articles{table_stores=(table_stores)stores[2],name="Kappa",price=35,total_in_shelf=10,total_in_vault=50},
            };

            articules3.ForEach(s => context.table_articles.Add(s));
            context.SaveChanges();
        }
    }
}
