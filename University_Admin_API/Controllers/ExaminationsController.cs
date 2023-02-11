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
    public class ExaminationsController : ControllerBase
    {
         private readonly ExaminationsService _examinationsService;

        public ExaminationsController(ExaminationsService examinationsService) =>
        _examinationsService = examinationsService;

        [HttpGet]
        [Route("GetExaminations")]
        public IActionResult GetExaminations()
        {
            return Ok(_examinationsService.GetExaminations());
        }

        [HttpPost]
        [Route("CreateExaminations")]
        public IActionResult PostExaminations(Examinations _examinations)
        {
            string msg;
            msg = _examinationsService.CreateExaminations(_examinations);
            return Ok(msg);
        }
    }
}
