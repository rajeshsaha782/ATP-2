using Aiub.Ums.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiub.Ums.Core.Service.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetById(int id);
        bool Insert(Student student);
        bool Update(Student student);
        bool Delete(int id);

        IEnumerable<Student> GetByName(string name);
        bool DeleteByName(string name);
    }
}
