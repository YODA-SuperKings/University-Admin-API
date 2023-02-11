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
    public class PaymentController : ControllerBase
    {
         private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService) =>
        _paymentService = paymentService;

        [HttpGet]
        [Route("GetPayment")]
        public IActionResult GetPayment()
        {
            return Ok(_paymentService.GetPayment());
        }

        [HttpPost]
        [Route("CreatePayment")]
        public IActionResult PostPayment(Payment _payment)
        {
            string msg;
            msg = _paymentService.CreatePayment(_payment);
            return Ok(msg);
        }
    }
}
