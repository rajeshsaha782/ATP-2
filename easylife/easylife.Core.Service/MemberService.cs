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
    class MemberService : IMemberService
    {
        DbContext _context;

        public MemberService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Member> GetAll()
        {
            return _context.Set<Member>().ToList();
        }

        public IEnumerable<Member> GetByEmail(string Email)
        {
            return _context.Set<Member>().Where(i => i.Email == Email);
        }

        public IEnumerable<Member> GetById(int Member_id)
        {
            return _context.Set<Member>().Where(i => i.Memeber_id == Member_id);
        }

        public IEnumerable<Member> GetByName(string Name)
        {
            return _context.Set<Member>().Where(i => i.Name == Name);
        }

        public IEnumerable<Member> GetByStatus(string Status)
        {
            return _context.Set<Member>().Where(i => i.Status == Status);
        }

        public IEnumerable<Member> GetByType(string Type)
        {
            return _context.Set<Member>().Where(i => i.Type == Type);
        }
        public bool Delete(int Member_id)
        {
            var deleteMemberservice= _context.Set<Member>().Where(i => i.Memeber_id == Member_id).SingleOrDefault();
            /// 

            if (deleteMemberservice != null)
            {
                _context.Set<Member>().Remove(deleteMemberservice);

            }
            return true;
        }

       

        public int GetPoint(int Member_id)
        {
            return 1;      
        }

        public bool Insert(Member member)
        {
            throw new NotImplementedException();
        }

        public bool SetPoint(int Member_id, int point)
        {
            throw new NotImplementedException();
        }

        public bool Update(Member member)
        {
            var updateMember = _context.Set<Member>().Where(i => i.Memeber_id == member.Memeber_id).SingleOrDefault();
            /// 

            if (updateMember != null)
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
