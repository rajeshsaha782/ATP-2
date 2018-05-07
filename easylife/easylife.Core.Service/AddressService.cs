using easylife.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using easylife.Core.Entities;
using System.Data.Entity;

namespace easylife.Core.Service
{
    public class AddressService : IAddressService
    {
        DbContext _context;

        public AddressService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Set<Address>().ToList();
        }


        public bool Delete(int AddressId)
        {
            var DeleteAddress = _context.Set<Address>().Where(i => i.AddressId == AddressId).SingleOrDefault();
            /// 

            if (DeleteAddress != null)
            {
                _context.Set<Address>().Remove(DeleteAddress);
                _context.SaveChanges();
            }
            return true;
        }


        public bool DeleteByMemberId(int MemberId)
        {
            var DeleteAddress = _context.Set<Address>().Where(i => i.MemberId == MemberId).SingleOrDefault();
            /// 

            if (DeleteAddress != null)
            {
                _context.Set<Address>().Remove(DeleteAddress);
                _context.SaveChanges();
            }
            return true;
        }

        public bool DeleteNoAdress(int MemberId)
        {
            var DeleteAddress = _context.Set<Address>().Where(i => i.MemberId == MemberId & i.MemberAddress == "No Address").SingleOrDefault();
            /// 

            if (DeleteAddress != null)
            {
                _context.Set<Address>().Remove(DeleteAddress);
                _context.SaveChanges();
            }
            return true;
        }
       

        public Address GetById(int AddressId)
        {
            return _context.Set<Address>().Where(i => i.AddressId == AddressId).SingleOrDefault();
        }


        public IEnumerable<Address> GetByMemberId(int MemberId)
        {
            return _context.Set<Address>().Where(i => i.MemberId == MemberId);
        }




        public bool Insert(Address address)
        {
            if (_context.Set<Address>().Add(address) == address)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update(Address address)
        {
            if (_context.Set<Address>().Any(e => e.AddressId == address.AddressId))
            {
                _context.Set<Address>().Attach(address);
                _context.Entry(address).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
            
        }
    }
}
