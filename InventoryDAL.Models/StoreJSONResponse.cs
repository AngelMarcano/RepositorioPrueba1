﻿using InventoryDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryDAL.Models
{
    public class StoreJSONResponse : JSONResponse
    {
        public table_stores[] stores { get; set; }
    }
}