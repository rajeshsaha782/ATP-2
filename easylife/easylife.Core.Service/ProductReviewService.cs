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
            var deleteFavorite = _context.Set<ProductReview>().Where(i => i.ReviewId == Review_id).SingleOrDefault();
            /// 

            if (deleteFavorite != null)
            {
                _context.Set<ProductReview>().Remove(deleteFavorite);

            }
            return true;
        }

        public IEnumerable<ProductReview> GetAll()
        {
            return _context.Set<ProductReview>().ToList();
        }

        public IEnumerable<ProductReview> GetById(int Review_id)
        {
            return _context.Set<ProductReview>().Where(i => i.ReviewId == Review_id);
        }

        public IEnumerable<ProductReview> GetByMemberId(int Member_id)
        {
            return _context.Set<ProductReview>().Where(i => i.MemberId == Member_id);
        }

        public IEnumerable<ProductReview> GetByProductId(int Product_id)
        {
            return _context.Set<ProductReview>().Where(i => i.ProductId == Product_id);
        }




        public bool Insert(ProductReview review)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductReview review)
        {
            var updateReview = _context.Set<ProductReview>().Where(i => i.ReviewId == review.ReviewId).SingleOrDefault();
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
