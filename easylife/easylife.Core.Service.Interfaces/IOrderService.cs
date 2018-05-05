using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(int OrderId);
        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int OrderId);

        IEnumerable<Order> GetByInvoiceId(int InvoiceId);
        IEnumerable<Order> GetByProductId(int ProductId);
        int CountByInvoiceId(int InvoiceId);
        
    }
}
