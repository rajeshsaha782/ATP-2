using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface IUserFavoriteService
    {
        IEnumerable<UserFavorite> GetAll();
        IEnumerable<UserFavorite> GetById(int UserFavoriteId);
        bool Insert(UserFavorite userfavorite);
        bool Update(UserFavorite userfavorite);
        bool Delete(int UserFavoriteId);

        IEnumerable<UserFavorite> GetByMemberId(int MemberId);
        IEnumerable<UserFavorite> GetByProductId(int ProductId);

        
    }
}
