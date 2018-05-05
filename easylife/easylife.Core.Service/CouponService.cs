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
    public class CouponService : ICouponService
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
            var deleteCoupon = _context.Set<Coupon>().Where(i => i.CouponId == Coupon_id).SingleOrDefault();
            /// 

            if (deleteCoupon != null)
            {
                _context.Set<Coupon>().Remove(deleteCoupon);
                _context.SaveChanges();
            }
            return true;
        }

        public bool DeleteByMemberId(int Member_id)
        {
            var deleteCoupon = _context.Set<Coupon>().Where(i => i.MemberId == Member_id).SingleOrDefault();
            /// 

            if (deleteCoupon != null)
            {
                _context.Set<Coupon>().Remove(deleteCoupon);
                _context.SaveChanges();
            }
            return true;
        }

       

        public Coupon GetById(int Coupon_id)
        {
            return _context.Set<Coupon>().Where(i => i.CouponId == Coupon_id).SingleOrDefault();
        }

        public IEnumerable<Coupon> GetByMemberId(int Member_id)
        {
            return _context.Set<Coupon>().Where(i => i.MemberId == Member_id);
        }


        public int CountByMemberId(int Member_id)
        {
            return _context.Set<Coupon>().Count(i => i.MemberId == Member_id);
        }


        public bool Insert(Coupon coupon)
        {
            if (_context.Set<Coupon>().Add(coupon) == coupon)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool isAvailable(int Coupon_id)
        {
            Coupon coupon = GetById(Coupon_id);
            if (coupon.Availability == "Available")
                return true;

            else
                return false;
        }

        public bool Update(Coupon coupon)
        {
            if (_context.Set<Coupon>().Any(e => e.CouponId == coupon.CouponId))
            {
                _context.Set<Coupon>().Attach(coupon);
                _context.Entry(coupon).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
