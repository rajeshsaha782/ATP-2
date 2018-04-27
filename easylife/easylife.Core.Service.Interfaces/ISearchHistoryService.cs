using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface ISearchHistoryService
    {
        IEnumerable<Search_History> GetAll();
        IEnumerable<Search_History> GetById(int Search_id);
        bool Insert(Search_History history);
        bool Update(Search_History history);
        bool Delete(int Search_id);

        IEnumerable<Search_History> GetByMemberId(int Member_id);
        IEnumerable<Search_History> GetByProductId(int Product_id);
        IEnumerable<Search_History> GetByCategory(string Category);
        
    }
}
