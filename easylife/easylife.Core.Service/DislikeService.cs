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
    public class DislikeService : IDislikeService
    {

        DbContext _context;

        public DislikeService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Dislike> GetAll()
        {
            return _context.Set<Dislike>().ToList();
        }

        public IEnumerable<Dislike> GetById(int Dislike_id)
        {
            return _context.Set<Dislike>().Where(i => i.DislikeId == Dislike_id);
        }

        public IEnumerable<Dislike> GetByMemberId(int Member_id)
        {
            return _context.Set<Dislike>().Where(i => i.MemberId == Member_id);
        }

        public IEnumerable<Dislike> GetByProductId(int Product_id)
        {
            return _context.Set<Dislike>().Where(i => i.ProductId == Product_id);
        }



        public int countdislike(int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Dislike_id)
        {
            var deleteDislike = _context.Set<Dislike>().Where(i => i.DislikeId == Dislike_id).SingleOrDefault();
            /// 

            if (deleteDislike != null)
            {
                _context.Set<Dislike>().Remove(deleteDislike);

            }
            return true;
        }

      

        public bool Insert(Dislike dislike)
        {
            if (_context.Set<Dislike>().Add(dislike) == dislike)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool SetDisike(int Member_id, int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool UnsetDisike(int Member_id, int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Dislike dislike)
        {
            var updatedislike = _context.Set<Dislike>().Where(i => i.DislikeId == dislike.DislikeId).SingleOrDefault();
            /// 

            if (updatedislike != null)
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
