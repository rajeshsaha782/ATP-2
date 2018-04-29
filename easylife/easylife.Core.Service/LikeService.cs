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
    class LikeService : ILikeService
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

        public IEnumerable<Like> GetById(int Address_id)
        {
            return _context.Set<Like>().Where(i => i.Like_id == Address_id);
        }

        public IEnumerable<Like> GetByMemberId(int Member_id)
        {
            return _context.Set<Like>().Where(i => i.Member_id == Member_id);
        }

        public IEnumerable<Like> GetByProductId(int Product_id)
        {
            return _context.Set<Like>().Where(i => i.Product_id == Product_id);
        }
        public int countlike(int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Address_id)
        {
            var deleteLike = _context.Set<Like>().Where(i => i.Like_id == Address_id).SingleOrDefault();
            /// 

            if (deleteLike != null)
            {
                _context.Set<Like>().Remove(deleteLike);

            }
            return true;
        }

      

        public bool Insert(Like address)
        {
            throw new NotImplementedException();
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
            var updateLike = _context.Set<Like>().Where(i => i.Like_id == address.Like_id).SingleOrDefault();
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
