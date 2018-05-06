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
        UserFavorite GetById(int UserFavoriteId);
        bool Insert(UserFavorite userfavorite);
        bool Update(UserFavorite userfavorite);
        bool Delete(int UserFavoriteId);
        bool Delete(int ProductId, int MemberId);

        bool isFavorite(int ProductId, int MemberId);

        IEnumerable<UserFavorite> GetByMemberId(int MemberId);
        IEnumerable<UserFavorite> GetByProductId(int ProductId);


    }
}
