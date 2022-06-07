using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Context;
using WebApplication9.IRepository;
using WebApplication9.Models;

namespace WebApplication9.Repository
{
    public class StudentRepo : IStudentRepo
    {
        AppDbContext _context;
        public StudentRepo(AppDbContext context)
        {
            _context = context;

        }
        void SaveDate()
        {
            _context.SaveChanges();
        }
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            SaveDate();
        }

        public Student GetStudentById(int id)
        {
            Student student = _context.Students.FirstOrDefault(x => x.Id == id);
            return student;
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();

        }
    }
}
