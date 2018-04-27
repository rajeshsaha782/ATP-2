using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAll();
        IEnumerable<Address> GetById(int Address_id);
        bool Insert(Address address);
        bool Update(Address address);
        bool Delete(int Address_id);

        IEnumerable<Address> GetByMember(int Member_id);
        bool DeleteByMember(int Member_id);
        //bool UpdateByMember(int address);


    }
}
