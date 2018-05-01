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
        bool isValidMember(int MemberId);
        string Login(int MemberId,string password);//return the type of member
    }
}
