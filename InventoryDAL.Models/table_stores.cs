using InventoryDAL.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDAL.Models
{
    [Table("table_stores")]
    public class table_stores : EntityBase
    {
        [Required]
        [StringLength(300, ErrorMessage = "La dirección no puede ser mayor a 300 carácteres")]
        [Display(Name = "Dirección")]
        public string address { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El nombre debe ser mayor a 2 carácteres y menor a 100 carácteres", MinimumLength = 2)]
        [Display(Name = "Nombre")]
        public string name { get; set; }
        [JsonIgnore]
        //[ForeignKey("store_id")]
        public virtual ICollection<table_articles> Articles { get; set; } = new HashSet<table_articles>();
    }
}
