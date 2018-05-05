using easylife.Core.Entities;
using easylife.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service
{
    public class LoginService : ILoginService
    {
        DbContext _context;

        public LoginService(DbContext context)
        {
            _context = context;
        }



        public bool isValidMember(string MemberEmail)
        {
            var member = _context.Set<Member>().Where(i => i.Email == MemberEmail).SingleOrDefault();

            if (member != null)
                return true;

            else
                return false;
        }

        public string Login(string MemberEmail, string password)
        {
            var member = _context.Set<Member>().Where(i => i.Email == MemberEmail).SingleOrDefault();

            if ((member != null) && (member.Password == password))
                return member.Type;

            else
                return "Invalid Password";
        }


        public bool isActive(string MemberEmail)
        {
            var member = _context.Set<Member>().Where(i => i.Email == MemberEmail).SingleOrDefault();

            if (member.Status == "1")
                return true;

            else
                return false;
        }
    }
}
