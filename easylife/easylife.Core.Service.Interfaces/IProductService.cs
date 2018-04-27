using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetById(int Product_id);
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int Product_id);

        IEnumerable<Product> GetByLessThanSellPrice(float price);
        IEnumerable<Product> GetByMoreThanSellPrice(float price);
        IEnumerable<Product> GetByCategory(string category);
        IEnumerable<Product> GetBySubCategory(string subcategory);
        IEnumerable<Product> GetByBrand(string brand);

        //IEnumerable<Product> GetByLessView();    //if functions are neccesary use order by query
        //IEnumerable<Product> GetByMoreView();
        //IEnumerable<Product> GetByLessSell();
        //IEnumerable<Product> GetByMoreSell();

        bool IncreasePrice(int Product_id,float Price);
        bool DecreasePrice(int Product_id,float Price);
        bool IncreaseQuantity(int Product_id, int Quantity);
        bool DecreaseQuantity(int Product_id, int Quantity);

        //concept of "like" needs more work
        bool like(int Product_id);  //increament like
        bool dislike(int Product_id);  //increament dislike

    }
}
