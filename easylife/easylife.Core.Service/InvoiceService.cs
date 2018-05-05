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

            if(deleteInvoice != null)
            {
                _context.Set<Invoice>().Remove(deleteInvoice);
                _context.SaveChanges();
            }
            return true;
        }


        public IEnumerable<Invoice> GetAll()
        {
            return _context.Set<Invoice>().ToList();
        }

        public IEnumerable<Invoice> GetByDate(DateTime Date)
        {
            return _context.Set<Invoice>().Where(i => i.Date == Date);
        }

        public Invoice GetById(int Invoice_id)
        {
            return _context.Set<Invoice>().Where(i => i.InvoiceId == Invoice_id).SingleOrDefault();
        }

        public IEnumerable<Invoice> GetByMemberId(int Member_id)
        {
            return _context.Set<Invoice>().Where(i => i.MemberId == Member_id);
        }

        public int CountByMemberId(int Member_id)
        {
            return _context.Set<Invoice>().Count(i => i.MemberId == Member_id);
        }

        public IEnumerable<Invoice> GetByPaid()
        {
            return _context.Set<Invoice>().Where(i => i.PaymentStatus == "Paid");
        }

        public IEnumerable<Invoice> GetByUnpaid()
        {
            return _context.Set<Invoice>().Where(i => i.PaymentStatus != "Paid");
        }

        public bool Insert(Invoice invoice)
        {
            if(_context.Set<Invoice>().Add(invoice) == invoice)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public Invoice Insert(Invoice invoice, bool returnInvoice)
        {
            Invoice I = new Invoice();

            I = _context.Set<Invoice>().Add(invoice);
            _context.SaveChanges();

            return I;

        }

        public bool SetStatus(int Invoice_id, string Status)
        {
            Invoice i = GetById(Invoice_id);
            i.Status = Status;
            return Update(i);
        }

        public bool Update(Invoice invoice)
        {
            if(_context.Set<Invoice>().Any(e => e.InvoiceId == invoice.InvoiceId))
            {
                _context.Set<Invoice>().Attach(invoice);
                _context.Entry(invoice).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
