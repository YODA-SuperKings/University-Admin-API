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
    public class UsersController : ControllerBase
    {
        private readonly UsersService _userService;
        private readonly StudentService _studentService;

        public UsersController(UsersService userService, StudentService studentService)
        {
            _userService = userService;
            _studentService = studentService;
        }

        [HttpGet]
        [Route("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser(string username, string password)
        {
            int loginType = 0;
            var user = _userService.GetUsers();
            if (user.Any() && (username != null || username != string.Empty) && (password != null || password != string.Empty))
            {
                loginType = user.Where(u => u.UserName == username && u.Password == password).Select(u => u.LoginType).FirstOrDefault();
            }
            return Ok(loginType);
        }

        [HttpGet]
        [Route("GetPaymentByID")]
        public IActionResult GetPaymentByID(string registrationNo)
        {
            Student _student = new Student();
            var studentInfo = _studentService.GetStudent();
            if (studentInfo.Any() && (registrationNo != null || registrationNo != string.Empty))
            {
                _student = studentInfo.Where(u => u.RegistrationNo == registrationNo).FirstOrDefault();
            }
            return Ok(_student);
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult PostUser(Users newUser)
        {
            string msg;
            msg = _userService.CreateUser(newUser);
            return Ok(msg);
        }
    }
}
