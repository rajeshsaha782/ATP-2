using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service
{
    public class IAddressService
    {
        IEnumerable<Address> GetAll();
        IEnumerable<Address> GetByMemberId(int id);
        bool Insert(Address address);
        bool Update(Address address);
        bool Delete(int id);
    }
}
