using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDAL.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        public virtual User UserInfo { get; set; }
    }
}
