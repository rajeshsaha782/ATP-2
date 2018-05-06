using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface IDislikeService
    {
        IEnumerable<Dislike> GetAll();
        Dislike GetById(int DislikeId);
        bool Insert(Dislike dislike);
        bool Update(Dislike dislike);
        bool Delete(int DislikeId);



        bool isDisLiked(int ProductId, int MemberId);

        IEnumerable<Dislike> GetByMemberId(int MemberId);
        IEnumerable<Dislike> GetByProductId(int ProductId);
        bool SetDisike(int MemberId, int ProductId);
        bool UnsetDisike(int MemberId, int ProductId);
        int countdislike(int ProductId);
    }
}
