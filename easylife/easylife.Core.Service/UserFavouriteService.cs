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
    public class UserFavouriteService : IUserFavoriteService
    {
        DbContext _context;

        public UserFavouriteService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Entities.UserFavorite> GetAll()
        {
            return _context.Set<UserFavorite>().ToList();
        }



        public bool Delete(int UserFavorite_id)
        {
            throw new NotImplementedException();
        }

       

        public IEnumerable<Entities.UserFavorite> GetById(int UserFavorite_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.UserFavorite> GetByMemberId(int Member_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.UserFavorite> GetByProductId(int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Entities.UserFavorite userfavorite)
        {
            throw new NotImplementedException();
        }

        public bool Update(Entities.UserFavorite userfavorite)
        {
            throw new NotImplementedException();
        }
    }
}
