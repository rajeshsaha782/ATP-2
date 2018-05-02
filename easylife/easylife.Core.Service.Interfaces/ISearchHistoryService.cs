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
        IEnumerable<SearchHistory> GetAll();
        SearchHistory GetById(int SearchId);
        bool Insert(SearchHistory history);
        bool Update(SearchHistory history);
        bool Delete(int SearchId);

        IEnumerable<SearchHistory> GetByMemberId(int MemberId);
        IEnumerable<SearchHistory> GetByProductId(int ProductId);
        IEnumerable<SearchHistory> GetByCategory(string Category);
        
    }
}
