using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    class IDislikeService
    {
        IEnumerable<Dislike> GetAll();
        IEnumerable<Dislike> GetById(int Dislike_id);
        bool Insert(Dislike dislike);
        bool Update(Dislike dislike);
        bool Delete(int Dislike_id);

        IEnumerable<Dislike> GetByMemberId(int Member_id);
        IEnumerable<Dislike> GetByProductId(int Product_id);
        bool SetDisike(int Member_id, int Product_id);
        bool UnsetDisike(int Member_id, int Product_id);
        int countdislike(int Product_id);
    }
}
