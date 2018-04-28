using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface ILikeService
    {
        IEnumerable<Like> GetAll();
        IEnumerable<Like> GetById(int Address_id);
        bool Insert(Like address);
        bool Update(Like address);
        bool Delete(int Address_id);

        IEnumerable<Like> GetByMemberId(int Member_id);
        IEnumerable<Like> GetByProductId(int Product_id);
        bool SetLike(int Member_id, int Product_id);
        bool UnsetLike(int Member_id, int Product_id);
        int countlike(int Product_id);

    }
}
