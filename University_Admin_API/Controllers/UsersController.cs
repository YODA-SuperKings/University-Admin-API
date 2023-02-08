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
