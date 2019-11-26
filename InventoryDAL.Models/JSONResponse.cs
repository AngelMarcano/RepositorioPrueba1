using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryDAL.Models
{
    [JsonObject(IsReference = false)]
    public class JSONResponse
    {
        public bool success { get; set; }
        public int total_elements { get; set; }
    }
}