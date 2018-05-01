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
    public class LikeService : ILikeService
    {
        DbContext _context;

        public LikeService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Like> GetAll()
        {
            return _context.Set<Like>().ToList();
        }

        public IEnumerable<Like> GetById(int AddressId)
        {
            return _context.Set<Like>().Where(i => i.LikeId == AddressId);
        }

        public IEnumerable<Like> GetByMemberId(int MemberId)
        {
            return _context.Set<Like>().Where(i => i.MemberId == MemberId);
        }

        public IEnumerable<Like> GetByProductId(int ProductId)
        {
            return _context.Set<Like>().Where(i => i.ProductId == ProductId);
        }
        public int countlike(int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int AddressId)
        {
            var deleteLike = _context.Set<Like>().Where(i => i.LikeId == AddressId).SingleOrDefault();
            /// 

            if (deleteLike != null)
            {
                _context.Set<Like>().Remove(deleteLike);

            }
            return true;
        }

      

        public bool Insert(Like address)
        {
            if (_context.Set<Like>().Add(address) == address)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool SetLike(int Member_id, int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool UnsetLike(int Member_id, int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Like address)
        {
            var updateLike = _context.Set<Like>().Where(i => i.LikeId == address.LikeId).SingleOrDefault();
            /// 

            if (updateLike != null)
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
