﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly UsersService _userService;

        public StudentController(StudentService studentService, UsersService userService) {
          _studentService = studentService;
          _userService = userService;
        }

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

        [HttpPost]
        [Route("UpdateStudent")]
        public IActionResult Update(string registrationCode)
        {
            string msg = "";
            var studentInfo = _studentService.GetStudent().Where(s=> s.RegistrationNo == registrationCode).FirstOrDefault();

            if (studentInfo is null)
            {
                return NotFound();
            }

            studentInfo.IsActive = true;
            msg = _studentService.CreateStudent(studentInfo);

            Users users = new Users();
            users.UserName = registrationCode;
            users.Password = "123";
            users.ConfirmPassword = "123";
            users.LoginType = 4;
            users.Email = studentInfo.Email;
            users.Name = studentInfo.CollegeName;
            if (users is null)
            {
                return NotFound();
            }



            return Ok("Updated Successfully");
        }
    }
}
