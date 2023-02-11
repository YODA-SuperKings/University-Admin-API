using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interface.Services.Users;
using BusinessLogic.Services.Users;
using Model = BusinessLogic.Model.Services.Users;

namespace University_Admin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _userService;

        public UsersController(UsersService userService) =>
        _userService = userService;

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
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult PostUser(Model::Users newUser)
        {
            string msg;
            msg = _userService.CreateUser(newUser);
            return Ok(msg);
        }
    }
}
