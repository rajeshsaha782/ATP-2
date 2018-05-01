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
        Member GetById(int Member_id);
        bool Insert(Member member);
        bool Update(Member member);
        bool Delete(int Member_id);


        IEnumerable<Member> GetByEmail(string Email);
        IEnumerable<Member> GetByName(string Name);
        IEnumerable<Member> GetByType(string Type);
        IEnumerable<Member> GetByStatus(string Status);

        int GetPoint(int Member_id);
        bool SetPoint(int Member_id,int point);

        //bool IncreasePoint(int Member_id);    //need point attribute for member
        //bool DecreasePoint(int Member_id);





    }
}
