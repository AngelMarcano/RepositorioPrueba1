using InventoryDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDAL.Repos
{
    public class StoreRepo : BaseRepo<table_stores>
    {
        public override List<table_stores> GetAll() => Context.table_stores.OrderBy(x => x.name).ToList();
    }
}
