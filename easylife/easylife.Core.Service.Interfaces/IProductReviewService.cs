using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface IProductReviewService
    {
        IEnumerable<Product_Review> GetAll();
        IEnumerable<Product_Review> GetById(int Review_id);
        bool Insert(Product_Review review);
        bool Update(Product_Review review);
        bool Delete(int Review_id);
    }
}
