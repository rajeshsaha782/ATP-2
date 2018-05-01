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
    public class InvoiceService : IInvoiceService
    {
        DbContext _context;

        public InvoiceService(DbContext context)
        {
            _context = context;
        }


        public bool Delete(int Invoice_id)
        {
            var deleteInvoice = _context.Set<Invoice>().Where(i => i.InvoiceId == Invoice_id).SingleOrDefault();

            if (deleteInvoice != null)
            {
                _context.Set<Invoice>().Remove(deleteInvoice);

            }
            return true;
        }
        

        public IEnumerable<Invoice> GetAll()
        {
            return _context.Set<Invoice>().ToList();
        }

        public IEnumerable<Invoice> GetByDate(DateTime Date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetById(int Invoice_id)
        {
            return _context.Set<Invoice>().Where(i => i.InvoiceId == Invoice_id);
        }

        public IEnumerable<Invoice> GetByMemberId(int Member_id)
        {
            return _context.Set<Invoice>().Where(i => i.id == Member_id);
        }

        public IEnumerable<Invoice> GetByPaid()
        {
            //return _context.Set<Invoice>().Where(i => i. == Product_id);
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetByUnpaid()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public bool SetStatus(int Invoice_id, string Status)
        {
            throw new NotImplementedException();
        }

        public bool Update(Invoice invoice)
        {
            var updateInvoice = _context.Set<Invoice>().Where(i => i.InvoiceId == invoice.InvoiceId).SingleOrDefault();
            /// 

            if (updateInvoice != null)
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
