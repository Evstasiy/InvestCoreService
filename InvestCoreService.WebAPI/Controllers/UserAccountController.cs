using Google.Api;
using InvestCoreService.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace InvestCoreService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountController : ControllerBase
    {
        private ILogger<UserAccountController> logger;
        private IUserAccountService accountService;
        public UserAccountController(ILogger<UserAccountController> logger, IUserAccountService accountService)
        {
            this.logger = logger;
            this.accountService = accountService;
        }

        [HttpGet("login")]
        public async Task<ActionResult> SetLogin()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                var claimsIdentity = new ClaimsIdentity("Undefined");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
            }

            return Ok();
        }
        
        [HttpGet("connectToBrokers")]
        public async Task<ActionResult> ConnectToBrokersAsync()
        {
            return Ok();
        }
        
        /// <summary>
        /// Загружаем данные о облигациях только 1 раз при старте
        /// </summary>
        /// <returns></returns>
        [HttpGet("brokers/upload/bonds")]
        public async Task<ActionResult> UploadAllUserBondsInBrokersAsync()
        {
            var userId = 1;
            await accountService.UploadAllUserBondsInBrokersAsync(userId);
            return Ok();
        }
    }
}
