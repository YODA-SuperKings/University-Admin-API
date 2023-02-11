using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Services;
using BusinessLogic.Model.Models;

namespace University_Admin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
         private readonly StudentService _studentService;

        public StudentController(StudentService studentService) =>
        _studentService = studentService;

        [HttpGet]
        [Route("GetStudent")]
        public IActionResult GetStudent()
        {
            return Ok(_studentService.GetStudent());
        }

        [HttpPost]
        [Route("CreateStudent")]
        public IActionResult PostStudent(Student _student)
        {
            string msg = "";
            if (_student != null)
            {
                msg = _studentService.CreateStudent(_student);
            }
            return Ok(msg);
        }
    }
}
