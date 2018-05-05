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
        Invoice GetById(int InvoiceId);
        bool Insert(Invoice invoice);
        Invoice Insert(Invoice invoice, bool returnInvoice);
        bool Update(Invoice invoice);
        bool Delete(int InvoiceId);

        IEnumerable<Invoice> GetByMemberId(int MemberId);
        IEnumerable<Invoice> GetByPaid();
        IEnumerable<Invoice> GetByUnpaid();
        IEnumerable<Invoice> GetByDate(DateTime Date);
        bool SetStatus(int InvoiceId, string Status);
        int CountByMemberId(int Member_id);

    }
}
