using InventoryDAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryDAL.Models.Account
{
    public class User : EntityBase
    {
        
        [DisplayName("Nombre de usuario:")]
        [Required]
        public string UserName { get; set; }
        [DisplayName("Contraseña:")]
        [Required]
        public string Password { get; set; }
                
        public virtual Role Role { get; set; }

        
        
    }
}
