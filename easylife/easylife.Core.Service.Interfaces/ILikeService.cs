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
        Like GetById(int AddressId);
        bool Insert(Like address);
        bool Update(Like address);
        bool Delete(int AddressId);


        bool isLiked(int ProductId, int MemberId);

        IEnumerable<Like> GetByMemberId(int MemberId);
        IEnumerable<Like> GetByProductId(int ProductId);
        bool SetLike(int MemberId, int ProductId);
        bool UnsetLike(int MemberId, int ProductId);
        int countlike(int ProductId);

    }
}
