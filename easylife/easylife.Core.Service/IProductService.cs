using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service
{
    public class IProductService
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategory(string category, string subCategory);
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int id);
    }
}
