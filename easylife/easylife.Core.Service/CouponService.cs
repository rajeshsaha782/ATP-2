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
    class CouponService : ICouponService
    {
        DbContext _context;

        public CouponService(DbContext context)
        {
            _context = context;
        }



        public IEnumerable<Coupon> GetAll()
        {
            return _context.Set<Coupon>().ToList();
        }


        public bool Delete(int Coupon_id)
        {
            var deleteCoupon = _context.Set<Coupon>().Where(i => i.Coupon_id == Coupon_id).SingleOrDefault();
            /// 

            if (deleteCoupon != null)
            {
                _context.Set<Coupon>().Remove(deleteCoupon);

            }
            return true;
        }

        public bool DeleteByMemberId(int Member_id)
        {
            var deleteCoupon = _context.Set<Coupon>().Where(i => i.Member_id == Member_id).SingleOrDefault();
            /// 

            if (deleteCoupon != null)
            {
                _context.Set<Coupon>().Remove(deleteCoupon);

            }
            return true;
        }

       

        public IEnumerable<Coupon> GetById(int Coupon_id)
        {
            return _context.Set<Coupon>().Where(i => i.Coupon_id == Coupon_id);
        }

        public IEnumerable<Coupon> GetByMemberId(int Member_id)
        {
            return _context.Set<Coupon>().Where(i => i.Member_id == Member_id);
        }



        public bool Insert(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public bool isAvailable(int Coupon_id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Coupon coupon)
        {
            throw new NotImplementedException();
        }
    }
}
