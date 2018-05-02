using easylife.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using easylife.Core.Entities;
using System.Data.Entity;

namespace easylife.Core.Service
{
    public class ProductService : IProductService
    {

        DbContext _context;

        public ProductService(DbContext context)
        {
            _context = context;
        }


        public IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>().ToList();
        }

        public IEnumerable<Product> GetByBrand(string brand)
        {
            return _context.Set<Product>().Where(i => i.Brand == brand);
        }

        public IEnumerable<Product> GetByCategory(string category, string subcategory)
        {
            return _context.Set<Product>().Where(i => i.Category == category && i.SubCategory==subcategory);
        }

        public IEnumerable<Product> GetBySearch(string search)
        {
            var result = from product in _context.Set<Product>()
                        where product.ProductName.ToLower().Contains(search.ToLower())
                       select product;
            return result.ToList();
        }

        public Product GetById(int Product_id)
        {
            return _context.Set<Product>().Where(i => i.ProductId == Product_id).FirstOrDefault();

        }

        public bool DecreasePrice(int Product_id, float Price)
        {
            throw new NotImplementedException();
        }

        public bool DecreaseQuantity(int Product_id, int Quantity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Product_id)
        {
            var deleteFavorite = _context.Set<Product>().Where(i => i.ProductId == Product_id).SingleOrDefault();
            /// 
            if (deleteFavorite != null)
            {
                _context.Set<Product>().Remove(deleteFavorite);

            }
            return true;
        }

       

        public IEnumerable<Product> GetByLessThanSellPrice(float price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetByMoreThanSellPrice(float price)
        {
            throw new NotImplementedException();
        }

        public int GetTotal_Sell(int Product_id)
        {
            throw new NotImplementedException();
        }

        public float GetTotal_Star(int Product_id)
        {
            throw new NotImplementedException();
        }

        public int GetTotal_Viewed(int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool IncreasePrice(int Product_id, float Price)
        {
            throw new NotImplementedException();
        }

        public bool IncreaseQuantity(int Product_id, int Quantity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Product product)
        {
            if(_context.Set<Product>().Add(product) == product)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool SetTotal_Sell(int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool SetTotal_Star(int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool SetTotal_Viewed(int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product product)
        {
            var updateProduct = _context.Set<Product>().Where(i => i.ProductId == product.ProductId).SingleOrDefault();
            /// 

            if (updateProduct != null)
            {
                return true;

            }
            else
            {
                return false;
            }
        }


      
    }
}
