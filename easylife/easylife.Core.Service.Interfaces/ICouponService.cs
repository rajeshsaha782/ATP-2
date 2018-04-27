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
        IEnumerable<Coupon> GetById(int Coupon_id);
        bool Insert(Coupon coupon);
        bool Update(Coupon coupon);
        bool Delete(int Coupon_id);


        IEnumerable<Coupon> GetByMember(int Member_id);
        bool isAvailable(int Coupon_id);
        bool DeleteByMember(int Member_id);

    }
}
