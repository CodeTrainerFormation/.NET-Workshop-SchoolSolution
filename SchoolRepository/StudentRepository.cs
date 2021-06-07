using Dal;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRepository
{
    public class StudentRepository : IStudentRepository
    {
        private SchoolContext context;

        public StudentRepository()
        {
            this.context = new SchoolContext();
        }

        public IQueryable<Student> GetStudents()
        {
            return this.context.Students;
        }

        public void AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
