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
    class OrderService : IOrderService
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
            throw new NotImplementedException();
        }

       

        public IEnumerable<Order> GetById(int Order_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetByInvoiceId(int Invoice_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetByProductId(int Product_id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Order order)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
