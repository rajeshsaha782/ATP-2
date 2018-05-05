using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface ILoginService
    {
        bool isValidMember(string MemberEmail);
        string Login(string MemberEmail, string password);//return the type of member
        bool isActive(string MemberEmail);
    }
}
