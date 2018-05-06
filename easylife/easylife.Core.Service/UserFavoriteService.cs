using easylife.Core.Service.Interfaces;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using easylife.Core.Entities;

namespace easylife.Core.Service
{
    public class UserFavoriteService : IUserFavoriteService
    {
        DbContext _context;

        public UserFavoriteService(DbContext context)
        {
            _context = context;
        }

        public UserFavoriteService()
        {
        }

        public IEnumerable<UserFavorite> GetAll()
        {
            return _context.Set<UserFavorite>().ToList();
        }


        public IEnumerable<UserFavorite> GetByMemberId(int Member_id)
        {
            return _context.Set<UserFavorite>().Where(i => i.MemeberId == Member_id);
        }


        //Console.WriteLine("Send");

        public bool Delete(int UserFavorite_id)
        {
            var deleteFavorite = _context.Set<UserFavorite>().Where(i => i.UserFavoriteId == UserFavorite_id).SingleOrDefault();
            /// 

            if(deleteFavorite != null)
            {
                _context.Set<UserFavorite>().Remove(deleteFavorite);
                _context.SaveChanges();
            }
            return true;
        }
        public bool Delete(int ProductId, int MemberId)
        {
            var deleteFavorite = _context.Set<UserFavorite>().Where(i => (i.ProductId == ProductId) && (i.MemeberId == MemberId)).SingleOrDefault();
            /// 

            if(deleteFavorite != null)
            {
                _context.Set<UserFavorite>().Remove(deleteFavorite);
                _context.SaveChanges();
            }
            return true;
        }

        public UserFavorite GetById(int UserFavorite_id)
        {
            return _context.Set<UserFavorite>().Where(i => i.UserFavoriteId == UserFavorite_id).SingleOrDefault();

        }

        public IEnumerable<UserFavorite> GetByProductId(int Product_id)
        {
            return _context.Set<UserFavorite>().Where(i => i.ProductId == Product_id);
        }

        public bool Insert(UserFavorite userfavorite)
        {
            if(_context.Set<UserFavorite>().Add(userfavorite) == userfavorite)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public bool isFavorite(int ProductId, int MemberId)
        {
            UserFavorite m = _context.Set<UserFavorite>().Where(i => (i.ProductId == ProductId) && (i.MemeberId == MemberId)).SingleOrDefault();

            if(m != null)
                return true;

            else
                return false;
        }

        public bool Update(UserFavorite userfavorite)
        {

            if(_context.Set<UserFavorite>().Any(e => e.UserFavoriteId == userfavorite.UserFavoriteId))
            {
                _context.Set<UserFavorite>().Attach(userfavorite);
                _context.Entry(userfavorite).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;

        }
    }
}
