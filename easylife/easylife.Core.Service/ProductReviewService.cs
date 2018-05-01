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
    public class ProductReviewService : IProductReviewService
    {
        DbContext _context;

        public ProductReviewService(DbContext context)
        {
            _context = context;
        }


        public bool Delete(int Review_id)
        {
            var deleteFavorite = _context.Set<Product_Review>().Where(i => i.Review_id == Review_id).SingleOrDefault();
            /// 

            if (deleteFavorite != null)
            {
                _context.Set<Product_Review>().Remove(deleteFavorite);

            }
            return true;
        }

        public IEnumerable<Product_Review> GetAll()
        {
            return _context.Set<Product_Review>().ToList();
        }

        public IEnumerable<Product_Review> GetById(int Review_id)
        {
            return _context.Set<Product_Review>().Where(i => i.Review_id == Review_id);
        }

        public IEnumerable<Product_Review> GetByMemberId(int Member_id)
        {
            return _context.Set<Product_Review>().Where(i => i.Member_id == Member_id);
        }

        public IEnumerable<Product_Review> GetByProductId(int Product_id)
        {
            return _context.Set<Product_Review>().Where(i => i.Product_id == Product_id);
        }




        public bool Insert(Product_Review review)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product_Review review)
        {
            var updateReview = _context.Set<Product_Review>().Where(i => i.Review_id == review.Review_id).SingleOrDefault();
            /// 

            if (updateReview != null)
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
