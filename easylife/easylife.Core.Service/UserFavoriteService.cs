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

        public IEnumerable<Entities.UserFavorite> GetAll()
        {
            return _context.Set<UserFavorite>().ToList();
        }


        public IEnumerable<Entities.UserFavorite> GetByMemberId(int Member_id)
        {
            return _context.Set<UserFavorite>().Where(i=>i.Memeber_id==Member_id);
        }


        //Console.WriteLine("Send");

        public bool Delete(int UserFavorite_id)
        {
            var deleteFavorite= _context.Set<UserFavorite>().Where(i=>i.UserFavorite_id == UserFavorite_id).SingleOrDefault();
            /// 
           
            if (deleteFavorite != null)
            {
                _context.Set<UserFavorite>().Remove(deleteFavorite);
        
            }
            return true;
        }


        public IEnumerable<Entities.UserFavorite> GetById(int UserFavorite_id)
        {
            return _context.Set<UserFavorite>().Where(i => i.UserFavorite_id == UserFavorite_id);
            
        }

        public IEnumerable<Entities.UserFavorite> GetByProductId(int Product_id)
        {
            return _context.Set<UserFavorite>().Where(i => i.Product_id == Product_id);
        }

        public bool Insert(Entities.UserFavorite userfavorite)
        {
            //_context.Set<UserFavorite>.Add(object userfavorite);

            return true;
            
        }

        public bool Update(Entities.UserFavorite userfavorite)
        {
        
            var updateFavorite = _context.Set<UserFavorite>().Where(i => i.UserFavorite_id ==userfavorite.UserFavorite_id).SingleOrDefault();
            /// 

            if (updateFavorite != null)
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
