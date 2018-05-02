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
            throw new NotImplementedException();
        }

        public string Login(string MemberEmail, string password)
        {
            throw new NotImplementedException();
        }
    }
}
