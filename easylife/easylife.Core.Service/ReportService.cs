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
    public class ReportService : IReportService
    {

        DbContext _context;

        public ReportService(DbContext context)
        {
            _context = context;
        }

        public bool Delete(int Report_id)
        {
            var deleteFavorite = _context.Set<Report>().Where(i =>i.ReportId == Report_id).SingleOrDefault();
            /// 
            if (deleteFavorite != null)
            {
                _context.Set<Report>().Remove(deleteFavorite);
                _context.SaveChanges();
            }
            return true;
        }

        public IEnumerable<Report> GetAll()
        {
            return _context.Set<Report>().ToList();
        }

        public IEnumerable<Report> GetByDate(DateTime Date)
        {
            return _context.Set<Report>().Where(i => i.Date == Date);
        }

        public Report GetById(int Report_id)
        {
            return _context.Set<Report>().Where(i => i.ReportId == Report_id).SingleOrDefault();
        }

        public IEnumerable<Report> GetByMemberId(int Member_id)
        {
            return _context.Set<Report>().Where(i => i.MemeberId == Member_id);
        }



        public IEnumerable<Report> GetBySeenStatus()
        {
            return _context.Set<Report>().Where(i => i.SeenStatus == "1");
        }

        public IEnumerable<Report> GetByTitle(string Title)
        {
            return _context.Set<Report>().Where(i => i.ReportTitle == Title);
        }

        public IEnumerable<Report> GetByUnseenStatus()
        {
            return _context.Set<Report>().Where(i => i.SeenStatus != "1");
        }

        public bool Insert(Report report)
        {
            if (_context.Set<Report>().Add(report) == report)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool SetSeen(int Report_id)
        {
            Report r = GetById(Report_id);
            r.SeenStatus = "1";
            return Update(r);
        }

        public bool SetUnseen(int Report_id)
        {
            Report r = GetById(Report_id);
            r.SeenStatus = "0";
            return Update(r);
        }

        public bool Update(Report report)
        {
            if (_context.Set<Report>().Any(e => e.ReportId == report.ReportId))
            {
                _context.Set<Report>().Attach(report);
                _context.Entry(report).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
