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
    class SearchHistoryService : ISearchHistoryService
    {

        DbContext _context;

        public SearchHistoryService(DbContext context)
        {
            _context = context;
        }


        public bool Delete(int Search_id)
        {
            var deleteFavorite = _context.Set<Search_History>().Where(i => i.Search_id == Search_id).SingleOrDefault();
            /// 
            if (deleteFavorite != null)
            {
                _context.Set<Search_History>().Remove(deleteFavorite);
            }
            return true;
        }

        public IEnumerable<Search_History> GetAll()
        {
            return _context.Set<Search_History>().ToList();
        }

        public IEnumerable<Search_History> GetByCategory(string Category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Search_History> GetById(int Search_id)
        {
            return _context.Set<Search_History>().Where(i => i.Search_id == Search_id);
        }

        public IEnumerable<Search_History> GetByMemberId(int Member_id)
        {
            return _context.Set<Search_History>().Where(i => i.Member_id == Member_id);
        }

        public IEnumerable<Search_History> GetByProductId(int Product_id)
        {
            return _context.Set<Search_History>().Where(i => i.Product_id == Product_id);
        }

        public bool Insert(Search_History history)
        {
            throw new NotImplementedException();
        }

        public bool Update(Search_History history)
        {
            var updateSearchHistory = _context.Set<Search_History>().Where(i => i.Search_id == history.Search_id).SingleOrDefault();
            /// 

            if (updateSearchHistory != null)
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
