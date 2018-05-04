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
        Member GetById(int MemberId);
        bool Insert(Member member);
        bool Update(Member member);
        bool Delete(int MemberId);


        IEnumerable<Member> GetByEmail(string Email);
        IEnumerable<Member> GetByName(string Name);
        IEnumerable<Member> GetByType(string Type);
        IEnumerable<Member> GetByStatus(string Status);

        int countMember();
        int GetPoint(int MemberId);
        bool SetPoint(int MemberId,int point);

        //bool IncreasePoint(int Member_id);    //need point attribute for member
        //bool DecreasePoint(int Member_id);





    }
}
