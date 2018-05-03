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
        IEnumerable<ProductReview> GetAll();
        ProductReview GetById(int ReviewId);
        bool Insert(ProductReview review);
        bool Update(ProductReview review);
        bool Delete(int ReviewId);

        IEnumerable<ProductReview> GetByMemberId(int MemberId);
        IEnumerable<ProductReview> GetByProductId(int ProductId);
        int CountReviewsByMemberId(int Member_id);
        
    }
}
