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
            return _context.Set<Product>().Where(i => i.Brand.Contains(brand));
        }

        public IEnumerable<Product> GetByCategory(string category, string subcategory)
        {
            return _context.Set<Product>().Where(i => i.Category == category && i.SubCategory==subcategory);
        }
        public IEnumerable<Product> GetByCategory(string category)
        {
            return _context.Set<Product>().Where(i => i.Category == category);
        }

        public IEnumerable<Product> NewProducts()
        {
            return _context.Set<Product>().Where(i => i.Date.Month == DateTime.Now.Month);
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
            Product p = GetById(Product_id);
            p.SellingPrice -= Price;
            return Update(p);
        }

        public bool DecreaseQuantity(int Product_id, int Quantity)
        {
            Product p = GetById(Product_id);
            p.Quantity -= Quantity;
            return Update(p);
        }

        public bool Delete(int Product_id)
        {
            var deleteFavorite = _context.Set<Product>().Where(i => i.ProductId == Product_id).SingleOrDefault();
            /// 
            if (deleteFavorite != null)
            {
                _context.Set<Product>().Remove(deleteFavorite);
                _context.SaveChanges();
            }
            return true;
        }

       

        public IEnumerable<Product> GetByLessThanSellPrice(float price)
        {
            return _context.Set<Product>().Where(i => i.SellingPrice < price);
        }

        public IEnumerable<Product> GetByMoreThanSellPrice(float price)
        {
            return _context.Set<Product>().Where(i => i.SellingPrice > price);
        }

        public int GetTotal_Sell(int Product_id)
        {
            Product p = GetById(Product_id);
            return p.TotalSell;
        }

        public float GetTotal_Star(int Product_id)
        {
            Product p = GetById(Product_id);
            return p.Star;
        }

        public int GetTotal_Viewed(int Product_id)
        {
            Product p = GetById(Product_id);
            return p.TotalViewed;
        }

        public bool IncreasePrice(int Product_id, float Price)
        {
            Product p = GetById(Product_id);
            p.SellingPrice += Price;
            return Update(p);
        }

        public bool IncreaseQuantity(int Product_id, int Quantity)
        {
            Product p = GetById(Product_id);
            p.Quantity += Quantity;
            return Update(p);
        }

        public bool Insert(Product product)
        {
            try
            {
                _context.Entry(product).State = EntityState.Added;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SetTotal_Sell(int Product_id)
        {
            Product p = GetById(Product_id);
            p.TotalSell++;
            return Update(p);
        }

        public bool SetTotal_Star(int Product_id)
        {
            LikeService l = new LikeService(_context);
            DislikeService d = new DislikeService(_context);
            float a = (float)(l.countlike(Product_id));
            float b = (float)(d.countdislike(Product_id));

            Product p = GetById(Product_id);
            p.Star=((a * 5) / (a + b));
            return Update(p);
        }

        public bool SetTotal_Viewed(int Product_id)
        {
            Product p = GetById(Product_id);
            p.TotalViewed++;
            return Update(p);
        }

        public bool Update(Product product)
        {
            if (_context.Set<Product>().Any(e => e.ProductId == product.ProductId))
            {
                _context.Set<Product>().Attach(product);
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }





       
    }
}
