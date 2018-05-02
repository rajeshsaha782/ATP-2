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
    public class MemberService : IMemberService
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

        public Member GetById(int Member_id)
        {
            return _context.Set<Member>().Where(i => i.MemberId == Member_id).SingleOrDefault();
        }

        public IEnumerable<Member> GetByName(string Name)
        {
            return _context.Set<Member>().Where(i => i.Name == Name);// need Like regular exspresion
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
            var deleteMemberservice= _context.Set<Member>().Where(i => i.MemberId == Member_id).SingleOrDefault();
            /// 

            if (deleteMemberservice != null)
            {
                _context.Set<Member>().Remove(deleteMemberservice);
                _context.SaveChanges();
            }
            return true;
        }

       

        public int GetPoint(int Member_id)
        {
            return GetById(Member_id).Point;      
        }

        public bool Insert(Member member)
        {
            if(_context.Set<Member>().Add(member) == member)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool SetPoint(int Member_id, int point)
        {
            Member m = GetById(Member_id);
            m.Point++;
            return Update(m);
        }

        public bool Update(Member member)
        {
            if (_context.Set<Member>().Any(e => e.MemberId == member.MemberId))
            {
                _context.Set<Member>().Attach(member);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
