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
        Product GetById(int ProductId);
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int ProductId);

        IEnumerable<Product> GetByLessThanSellPrice(float price);
        IEnumerable<Product> GetByMoreThanSellPrice(float price);
        IEnumerable<Product> GetByCategory(string category, string subcategory);
        IEnumerable<Product> GetBySearch(string search);
        IEnumerable<Product> GetByCategory(string category);
        IEnumerable<Product> GetByBrand(string brand);
        IEnumerable<Product> NewProducts();

        //IEnumerable<Product> GetByLessView();    //if functions are neccesary use order by query
        //IEnumerable<Product> GetByMoreView();
        //IEnumerable<Product> GetByLessSell();
        //IEnumerable<Product> GetByMoreSell();

        bool IncreasePrice(int ProductId,float Price);
        bool DecreasePrice(int ProductId,float Price);
        bool IncreaseQuantity(int ProductId, int Quantity);
        bool DecreaseQuantity(int ProductId, int Quantity);

        bool SetTotal_Viewed(int ProductId);//increment by 1
        bool SetTotal_Sell(int ProductId);//increment by 1
        
        int GetTotal_Viewed(int ProductId);
        int GetTotal_Sell(int ProductId);

        bool SetTotal_Star(int ProductId);//Countlike(productid)*5/countlike(productid)+countdislike(productid)
        float GetTotal_Star(int ProductId);



    }
}
