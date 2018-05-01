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

        public bool isValidMember(int MemberId)
        {
            throw new NotImplementedException();
        }

        public string Login(int MemberId, string password)
        {
            throw new NotImplementedException();
        }

        bool ILoginService.isValidMember(int MemberId)
        {
            throw new NotImplementedException();
        }

        string ILoginService.Login(int MemberId, string password)
        {
            throw new NotImplementedException();
        }
    }
}
