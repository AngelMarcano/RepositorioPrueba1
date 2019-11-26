using InventoryDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDAL.Models.Account
{
    public class Role : EntityBase
    {
        public string Name { get; set; }
    }
}
