using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9.IRepository
{
   public interface IStudentRepo
    {
        void AddStudent(Student student);
        List<Student> GetStudents();
        Student GetStudentById(int id);

    }
}
