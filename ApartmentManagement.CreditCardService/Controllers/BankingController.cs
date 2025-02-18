﻿using ApartmentManagement;
using ApartmentManagement.CreditCardService.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagement.CreditCardService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class BankingController : ControllerBase
    {
        private readonly ApartmentManagement.CreditCardService.Services.CreditCardService _creditCardService;
        public BankingController(ApartmentManagement.CreditCardService.Services.CreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("WithdrawMoney")]
        public async Task<IActionResult> WithdrawMoney(CreditCardViewModel model)
        {
            var result = await _creditCardService.WithdrawMoney(new ApartmentManagement.CreditCardService.Model.Mongo.CreditCard
            {
                CardNumber = model.CardNumber,
                Cvv = model.Cvv,
                Owner = model.Owner,
                ValidMonth = model.ValidMonth,
                ValidYear = model.ValidYear
            }, model.Money);
            return Ok(result);
        }
    }
}
