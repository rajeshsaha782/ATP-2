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

        public Like GetById(int LikeId)
        {
            return _context.Set<Like>().Where(i => i.LikeId == LikeId).SingleOrDefault();
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
            return _context.Set<Like>().Count(i => i.ProductId == Product_id);
        }

        public bool Delete(int LikeId)
        {
            var deleteLike = _context.Set<Like>().Where(i => i.LikeId == LikeId).SingleOrDefault();
            /// 

            if(deleteLike != null)
            {
                _context.Set<Like>().Remove(deleteLike);
                _context.SaveChanges();
            }
            return true;
        }


        public bool Insert(Like like)
        {
            if(_context.Set<Like>().Add(like) == like)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool SetLike(int Member_id, int Product_id)
        {
            Like l = new Like();
            l.MemberId = Member_id;
            l.ProductId = Product_id;
            return Insert(l);
        }

        public bool UnsetLike(int Member_id, int Product_id)
        {
            var deleteLike = _context.Set<Like>().Where(i => (i.MemberId == Member_id) && (i.ProductId == Product_id)).SingleOrDefault();
            /// 

            if(deleteLike != null)
            {
                _context.Set<Like>().Remove(deleteLike);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update(Like like)
        {
            if(_context.Set<Like>().Any(e => e.LikeId == like.LikeId))
            {
                _context.Set<Like>().Attach(like);
                _context.Entry(like).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }


        public bool isLiked(int ProductId, int MemberId)
        {
            Like m = _context.Set<Like>().Where(i => (i.ProductId == ProductId) & (i.MemberId == MemberId)).SingleOrDefault();

            if(m != null)
                return true;

            else
                return false;
        }
    }
}
