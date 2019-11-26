using InventoryDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryDAL.Models
{
    public class ArticleJSONResponse : JSONResponse
    {
        public table_articles[] articles { get; set; }
    }
}