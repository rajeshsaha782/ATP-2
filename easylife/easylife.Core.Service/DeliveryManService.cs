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
    public class DeliveryManService : IDeliveryManService
    {
        DbContext _context;

        public DeliveryManService(DbContext context)
        {
            _context = context;
        }


        public IEnumerable<Delivery_Man> GetAll()
        {
            return _context.Set<Delivery_Man>().ToList();
        }


        public bool Delete(int Delivery_Man_id)
        {
            var deleteDeliveryMan = _context.Set<Delivery_Man>().Where(i => i.Delivery_Man_id == Delivery_Man_id).SingleOrDefault();
            /// 

            if (deleteDeliveryMan != null)
            {
                _context.Set<Delivery_Man>().Remove(deleteDeliveryMan);

            }
            return true;
        }



        public IEnumerable<Delivery_Man> GetById(int Delivery_Man_id)
        {
            return _context.Set<Delivery_Man>().Where(i => i.Delivery_Man_id == Delivery_Man_id);
        }

        public IEnumerable<Delivery_Man> GetByMemberId(int Member_id)
        {
            return _context.Set<Delivery_Man>().Where(i => i.Member_id == Member_id);
        }



        public IEnumerable<Delivery_Man> GetByAvailability()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Delivery_Man> GetByUnavailability()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Delivery_Man delivery_Man)
        {
            throw new NotImplementedException();
        }

        public bool Update(Delivery_Man delivery_Man)
        {
            var updatedelivery_man = _context.Set<Delivery_Man>().Where(i => i.Delivery_Man_id == delivery_Man.Delivery_Man_id).SingleOrDefault();
            /// 

            if (updatedelivery_man != null)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
