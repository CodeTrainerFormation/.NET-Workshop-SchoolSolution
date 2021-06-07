using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchool.Repositories
{
    public interface IStudentRepository
    {
        public IQueryable<Student> GetStudents();
        public void AddStudent(Student student);
        public void DeleteStudent(Student student);
    }
}
