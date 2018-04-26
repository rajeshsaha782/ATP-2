using Aiub.Ums.Core.Entities;
using Aiub.Ums.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiub.Ums.Core.Service
{
    public class StudentService : IStudentService
    {
        DbContext _context;

        public StudentService(DbContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Set<Student>().ToList();
        }

        public IEnumerable<Student> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Student student)
        {
            throw new NotImplementedException();
        }

        public bool Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
