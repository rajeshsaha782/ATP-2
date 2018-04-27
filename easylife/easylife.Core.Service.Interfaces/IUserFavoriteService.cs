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
        IEnumerable<UserFavorite> GetById(int UserFavorite_id);
        bool Insert(UserFavorite userfavorite);
        bool Update(UserFavorite userfavorite);
        bool Delete(int UserFavorite_id);

        IEnumerable<UserFavorite> GetByMemberId(int Member_id);
        IEnumerable<UserFavorite> GetByProductId(int Product_id);
        
    }
}
