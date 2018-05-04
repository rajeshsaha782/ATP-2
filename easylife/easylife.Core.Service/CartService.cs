using easylife.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service
{
    public class CartService : ICartService
    {

        IEnumerable<Entities.Cart> ICartService.GetAll()
        {
            throw new NotImplementedException();
        }

        Entities.Cart ICartService.GetById(int CartId)
        {
            throw new NotImplementedException();
        }

        bool ICartService.Insert(Entities.Cart Cart)
        {
            throw new NotImplementedException();
        }

        bool ICartService.Update(Entities.Cart Cart)
        {
            throw new NotImplementedException();
        }

        bool ICartService.Delete(int CartId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Entities.Cart> ICartService.GetByMemberId(int MemberId)
        {
            throw new NotImplementedException();
        }
    }
}
