using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface ICouponService
    {
        IEnumerable<Coupon> GetAll();
        Coupon GetById(int CouponId);
        bool Insert(Coupon coupon);
        bool Update(Coupon coupon);
        bool Delete(int CouponId);


        IEnumerable<Coupon> GetByMemberId(int Member_id);
        bool isAvailable(int CouponId);
        bool DeleteByMemberId(int MemberId);
        int CountByMemberId(int Member_id);

    }
}
