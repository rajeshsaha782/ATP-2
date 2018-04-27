using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface IInvoiceService
    {
        IEnumerable<Invoice> GetAll();
        IEnumerable<Invoice> GetById(int Invoice_id);
        bool Insert(Invoice invoice);
        bool Update(Invoice invoice);
        bool Delete(int Invoice_id);

        IEnumerable<Invoice> GetByMember(int Member_id);
        IEnumerable<Invoice> GetByPaid();
        IEnumerable<Invoice> GetByUnpaid();
        IEnumerable<Invoice> GetByDate(DateTime Date);

    }
}
