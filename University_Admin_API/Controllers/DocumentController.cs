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
    public class DocumentController : ControllerBase
    {
         private readonly DocumentService _documentService;

        public DocumentController(DocumentService documentService) =>
        _documentService = documentService;

        [HttpGet]
        [Route("GetDocument")]
        public IActionResult GetDocument()
        {
            return Ok(_documentService.GetDocument());
        }

        [HttpPost]
        [Route("CreateDocument")]
        public IActionResult PostDocument(Document _document)
        {
            string msg = "";
            if (_document != null)
            {
                msg = _documentService.CreateDocument(_document);
            }
            return Ok(msg);
        }
    }
}
