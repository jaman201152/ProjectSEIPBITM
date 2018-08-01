using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemUI.Model
{
    public static class Common
    {

        public static string ConnectionString()
        {
            string conString = @"server=DESKTOP-FD57AFH\SQLEXPRESS; database=StockManagementSystemBatch50; integrated security=true";
            return conString;
        }

    }
}
