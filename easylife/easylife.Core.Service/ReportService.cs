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

            }
            return true;
        }

        public IEnumerable<Report> GetAll()
        {
            return _context.Set<Report>().ToList();
        }

        public IEnumerable<Report> GetByDate(DateTime Date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> GetById(int Report_id)
        {
            return _context.Set<Report>().Where(i => i.ReportId == Report_id);
        }

        public IEnumerable<Report> GetByMemberId(int Member_id)
        {
            return _context.Set<Report>().Where(i => i.MemeberId == Member_id);
        }



        public IEnumerable<Report> GetBySeenStatus()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> GetByTitle(string Title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> GetByUnseenStatus()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Report report)
        {
            throw new NotImplementedException();
        }

        public bool SetSeen(int Report_id)
        {
            throw new NotImplementedException();
        }

        public bool SetUnseen(int Report_id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Report report)
        {
            var updateReport = _context.Set<Report>().Where(i => i.ReportId == report.ReportId).SingleOrDefault();
            /// 

            if (updateReport != null)
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
