﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemUI.Model
{
   public class StockOut
    {

        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long CampanyId { get; set; }
        public long ItemId { get; set; }
<<<<<<< HEAD
        public int StockOutQuantity { get; set; }
        public DateTime StockOutDate { get; set; }

    public  enum StockOutType{
          Sell=1,
          Damage=2,
          Lose=3
       } 
=======
        public int AvailableQuantity { get; set; }

>>>>>>> 87eab73d3446977816d7eefdc0fe8f147edc38f5
    }
}
