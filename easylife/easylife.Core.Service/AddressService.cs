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


        public bool Delete(int Address_id)
        {
            var DeleteAddress = _context.Set<Address>().Where(i => i.Address_id == Address_id).SingleOrDefault();
            /// 

            if (DeleteAddress != null)
            {
                _context.Set<Address>().Remove(DeleteAddress);

            }
            return true;
        }


        public bool DeleteByMemberId(int Member_id)
        {
            var DeleteAddress = _context.Set<Address>().Where(i => i.Member_id == Member_id).SingleOrDefault();
            /// 

            if (DeleteAddress != null)
            {
                _context.Set<Address>().Remove(DeleteAddress);

            }
            return true;
        }

       

        public IEnumerable<Address> GetById(int Address_id)
        {
            return _context.Set<Address>().Where(i => i.Address_id == Address_id);
        }


        public IEnumerable<Address> GetByMemberId(int Member_id)
        {
            return _context.Set<Address>().Where(i => i.Member_id == Member_id);
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
            if (_context.Set<Address>().Any(e => e.Address_id == address.Address_id))
            {
                _context.Set<Address>().Attach(address);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
            
        }
    }
}
