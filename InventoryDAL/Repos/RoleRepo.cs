using InventoryDAL.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDAL.Repos
{
    public class RoleRepo : BaseRepo<Role>
    {
        public override List<Role> GetAll() => Context.Role.Include("User").OrderBy(x => x.Name).ToList();
    }
}
