﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemUI.Model
{
   public class StockIn
    {
       public long CategoryId { get; set; }
       public long CampanyId { get; set; }
       public long ItemId { get; set; }
       public int AvailableQuantity { get; set; }
    }
}