using easylife.Core.Entities;
using easylife.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service
{
    public class CartService : ICartService
    {
        DbContext _context;

        public CartService(DbContext context)
        {
            _context = context;
        }



        public IEnumerable<Cart> GetAll()
        {
            return _context.Set<Cart>().ToList();
        }

        public Cart GetById(int CartId)
        {
            return _context.Set<Cart>().Where(i => i.CartId == CartId).SingleOrDefault();
        }

        public bool Insert(Cart Cart)
        {
            if(_context.Set<Cart>().Add(Cart) == Cart)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update(Cart Cart)
        {
            if(_context.Set<Cart>().Any(e => e.CartId == Cart.CartId))
            {
                _context.Set<Cart>().Attach(Cart);
                _context.Entry(Cart).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Delete(int CartId)
        {
            var DeleteCart= _context.Set<Cart>().Where(i => i.CartId == CartId).SingleOrDefault();
            /// 

            if(DeleteCart != null)
            {
                _context.Set<Cart>().Remove(DeleteCart);
                _context.SaveChanges();
            }
            return true;
        }

        public bool DeleteByMemberId(int MemberId)
        {
            var DeleteCart = _context.Set<Cart>().Where(i => i.MemberId == MemberId).ToList();
            /// 
            int flag = 0;
            foreach (var cart in DeleteCart)
            {
                if (cart != null)
                {
                    _context.Set<Cart>().Remove(cart);
                    _context.SaveChanges();
                    flag = 1;
                }
                else
                {
                    flag = 0;
                    break;
                }      
            }
            if (flag == 1)
                return true;

            else
                return false;

            
        }

        public IEnumerable<Cart> GetByMemberId(int MemberId)
        {
            return _context.Set<Cart>().Where(i => i.MemberId == MemberId);
        }
    }
}
