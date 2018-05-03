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
    public class SearchHistoryService : ISearchHistoryService
    {

        DbContext _context;

        public SearchHistoryService(DbContext context)
        {
            _context = context;
        }


        public bool Delete(int Search_id)
        {
            var deleteFavorite = _context.Set<SearchHistory>().Where(i => i.SearchId == Search_id).SingleOrDefault();
            /// 
            if (deleteFavorite != null)
            {
                _context.Set<SearchHistory>().Remove(deleteFavorite);
            }
            return true;
        }

        public IEnumerable<SearchHistory> GetAll()
        {
            return _context.Set<SearchHistory>().ToList();
        }

        public IEnumerable<SearchHistory> GetByCategory(string Category)
        {
            return _context.Set<SearchHistory>().Where(i => i.ProductCategory == Category);
        }

        public SearchHistory GetById(int Search_id)
        {
            return _context.Set<SearchHistory>().Where(i => i.SearchId == Search_id).SingleOrDefault();
        }

        public IEnumerable<SearchHistory> GetByMemberId(int Member_id)
        {
            return _context.Set<SearchHistory>().Where(i => i.MemberId == Member_id);
        }

        public IEnumerable<SearchHistory> GetByProductId(int Product_id)
        {
            return _context.Set<SearchHistory>().Where(i => i.ProductId == Product_id);
        }

        public bool Insert(SearchHistory history)
        {
            if (_context.Set<SearchHistory>().Add(history) == history)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update(SearchHistory history)
        {
            if (_context.Set<SearchHistory>().Any(e => e.SearchId == history.SearchId))
            {
                _context.Set<SearchHistory>().Attach(history);
                _context.Entry(history).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
