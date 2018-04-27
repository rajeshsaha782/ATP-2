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
        IEnumerable<Report> GetById(int Report_id);
        bool Insert(Report report);
        bool Update(Report report);
        bool Delete(int Report_id);
    }
}
