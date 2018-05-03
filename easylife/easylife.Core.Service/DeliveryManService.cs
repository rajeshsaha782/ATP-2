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


        public IEnumerable<DeliveryMan> GetAll()
        {
            return _context.Set<DeliveryMan>().ToList();
        }


        public bool Delete(int DeliveryManId)
        {
            var deleteDeliveryMan = _context.Set<DeliveryMan>().Where(i => i.MemberId == DeliveryManId).SingleOrDefault();
            /// 

            if (deleteDeliveryMan != null)
            {
                _context.Set<DeliveryMan>().Remove(deleteDeliveryMan);
                _context.SaveChanges();
            }
            return true;
        }



        public DeliveryMan GetById(int DeliveryManId)
        {
            return _context.Set<DeliveryMan>().Where(i => i.MemberId == DeliveryManId).SingleOrDefault();
        }

        public IEnumerable<DeliveryMan> GetByMemberId(int MemberId)
        {
            return _context.Set<DeliveryMan>().Where(i => i.MemberId == MemberId);
        }



        public IEnumerable<DeliveryMan> GetByAvailability()
        {
            return _context.Set<DeliveryMan>().Where(i => i.Availability == "Available");
        }
        public IEnumerable<DeliveryMan> GetByUnavailability()
        {
            return _context.Set<DeliveryMan>().Where(i => i.Availability != "Available");
        }

        public bool Insert(DeliveryMan delivery_Man)
        {
            if (_context.Set<DeliveryMan>().Add(delivery_Man) == delivery_Man)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update(DeliveryMan deliveryMan)
        {
            if (_context.Set<DeliveryMan>().Any(e => e.Id == deliveryMan.Id))
            {
                _context.Set<DeliveryMan>().Attach(deliveryMan);
                _context.Entry(deliveryMan).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
