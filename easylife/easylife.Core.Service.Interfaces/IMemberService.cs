using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<Member> GetAll();
        IEnumerable<Member> GetById(int Member_id);
        bool Insert(Member member);
        bool Update(Member member);
        bool Delete(int Member_id);
    }
}
