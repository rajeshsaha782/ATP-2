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
        IEnumerable<Order> GetById(int Order_id);
        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int Order_id);

        IEnumerable<Order> GetByInvoiceId(int Invoice_id);
        IEnumerable<Order> GetByProductId(int Product_id);
        
    }
}
