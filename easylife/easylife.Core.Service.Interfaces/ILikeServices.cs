using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface ILikeServices
    {
        IEnumerable<Like> GetAll();
        IEnumerable<Like> GetById(int Like_id);
        bool Insert(Like like);
        bool Update(Like like);
        bool Delete(int Like_id);

        IEnumerable<Like> GetByMemberId(int Member_id);
        IEnumerable<Like> GetByProductId(int Product_id);
        bool SetLike(int Member_id, int Product_id);
        bool UnsetLike(int Member_id, int Product_id);
        int countlike(int Product_id);
    }
}
