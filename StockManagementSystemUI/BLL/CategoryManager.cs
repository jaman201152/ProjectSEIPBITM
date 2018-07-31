using StockManagementSystemUI.Category.DAL;
using StockManagementSystemUI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemUI.Category.BLL
{
    public class CategoryManager
    {
        CategoryRepository _CategoryRepository = new CategoryRepository();
        
        public bool Add(Model.Category category)
        {
            bool isAdded = _CategoryRepository.Add(category);
            return isAdded;

        }

        public DataTable CategoryLode(CategoryManager categoryManager)
        {
            return _CategoryRepository.CategoryLode(categoryManager);
        }
    }
}
