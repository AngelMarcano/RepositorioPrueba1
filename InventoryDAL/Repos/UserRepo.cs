using InventoryDAL.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDAL.Repos
{
    public class UserRepo : BaseRepo<User>
    {
        
        public override List<User> GetAll() => Context.User.OrderBy(x => x.UserName).ToList();
    }
}
