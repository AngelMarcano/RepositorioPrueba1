using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWebAPI.Models
{

    //crear estas entidades cómo modelView para retornarlos al cliente desde el servicio webAPI
    //crear los formatos json de salida 
    [JsonObject(IsReference = false)]
    public class JSONErrorResponse
    {
        public string error_msg { get; set; }
        public int error_code { get; set; }
        public bool success { get; set; }
    }
}
