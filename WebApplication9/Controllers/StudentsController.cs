using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.IRepository;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentRepo _repo;
        public StudentsController(IStudentRepo repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetStudents());
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            _repo.AddStudent(student);
            return Created("added", student);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
    {
            return Ok(_repo.GetStudentById(id));
    }
    }
}
