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
    public class table_articles: EntityBase
    {
       
        [Required]
        [StringLength(100, ErrorMessage = "El Nombre no puede ser mayor a 100 carácteres", MinimumLength = 2)]
        [Display(Name = "Nombre")]
        public string name { get; set; }
        [StringLength(300, ErrorMessage = "La descripción no puede ser mayor a 300 carácteres")]
        [Display(Name = "Descripción")]
        public string description { get; set; }
        [Required]
        [Range(0, 9999999999999999.99)]
        [Display(Name = "Precio")]
        public decimal price { get; set; }
        [Display(Name = "Estante")]
        public int total_in_shelf { get; set; }
        [Display(Name = "Depósito")]
        public int total_in_vault { get; set; }
        //[JsonIgnore]
        [Column("store_id")]
        public virtual table_stores table_stores { get; set; }
        //[JsonIgnore]
        [ForeignKey("table_stores")]
        [Display(Name = "Tienda")]
        public int store_id { get; set; }
        [NotMapped]
        public string store_name { get; set; }
    }
}
