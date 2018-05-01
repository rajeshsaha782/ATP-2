﻿using easylife.Core.Entities;
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
        IEnumerable<Address> GetById(int AddressId);
        bool Insert(Address address);
        bool Update(Address address);
        bool Delete(int AddressId);

        IEnumerable<Address> GetByMemberId(int MemberId);
        bool DeleteByMemberId(int MemberId);
        //bool UpdateByMember(int address);


    }
}
