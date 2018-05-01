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

            }
            return true;
        }

       

        public IEnumerable<Order> GetById(int Order_id)
        {
            return _context.Set<Order>().Where(i => i.OrderId == Order_id);
        }

        public IEnumerable<Order> GetByInvoiceId(int Invoice_id)
        {
            return _context.Set<Order>().Where(i => i.InvoiceId == Invoice_id);
        }

        public IEnumerable<Order> GetByProductId(int Product_id)
        {
            return _context.Set<Order>().Where(i => i.ProductId == Product_id);
        }



        public bool Insert(Order order)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order order)
        {
            var updateOrder = _context.Set<Order>().Where(i => i.OrderId == order.OrderId).SingleOrDefault();
            /// 

            if (updateOrder != null)
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
