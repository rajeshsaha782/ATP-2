using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface ICartService
    {
        IEnumerable<Cart> GetAll();
        Cart GetById(int CartId);
        bool Insert(Cart Cart);
        bool Update(Cart Cart);
        bool Delete(int CartId);

        IEnumerable<Cart> GetByMemberId(int MemberId);
        bool DeleteByMemberId(int MemberId);
        
    }
}
