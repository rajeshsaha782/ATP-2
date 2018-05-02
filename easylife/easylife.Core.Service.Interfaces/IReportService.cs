using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface IReportService
    {
        IEnumerable<Report> GetAll();
        Report GetById(int ReportId);
        bool Insert(Report report);
        bool Update(Report report);
        bool Delete(int ReportId);

        IEnumerable<Report> GetByMemberId(int MemberId);
        IEnumerable<Report> GetByTitle(string Title);
        IEnumerable<Report> GetByDate(DateTime Date);
        IEnumerable<Report> GetBySeenStatus();
        IEnumerable<Report> GetByUnseenStatus();
        bool SetSeen(int ReportId);
        bool SetUnseen(int ReportId);
        
    }
}
