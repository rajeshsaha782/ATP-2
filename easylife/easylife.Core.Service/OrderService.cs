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
    public class OrderService : IOrderService
    {
        DbContext _context;

        public OrderService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Set<Order>().ToList();
        }


        public bool Delete(int Order_id)
        {
            var deleteOrder = _context.Set<Order>().Where(i => i.OrderId == Order_id).SingleOrDefault();
            /// 

            if (deleteOrder != null)
            {
                _context.Set<Order>().Remove(deleteOrder);
                _context.SaveChanges();
            }
            return true;
        }

       

        public Order GetById(int Order_id)
        {
            return _context.Set<Order>().Where(i => i.OrderId == Order_id).SingleOrDefault();
        }

        public IEnumerable<Order> GetByInvoiceId(int Invoice_id)
        {
            return _context.Set<Order>().Where(i => i.InvoiceId == Invoice_id);
        }

        public int CountByInvoiceId(int InvoiceId)
        {
            return _context.Set<Order>().Count(i => i.InvoiceId == InvoiceId);
        }

        public IEnumerable<Order> GetByProductId(int Product_id)
        {
            return _context.Set<Order>().Where(i => i.ProductId == Product_id);
        }



        public bool Insert(Order order)
        {
            if (_context.Set<Order>().Add(order) == order)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update(Order order)
        {
            if (_context.Set<Order>().Any(e => e.OrderId == order.OrderId))
            {
                _context.Set<Order>().Attach(order);
                _context.Entry(order).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
