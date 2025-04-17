using InvestCoreService.API.Contracts.Requests;
using InvestCoreService.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(UserRegisterRequest request)
        {
            await this.accountService.Register(request.UserName, request.Email, request.Password);
            return Ok();
        }
        
        [HttpPost("login")]
        public async Task<ActionResult> SetLoginAsync(UserLoginRequest request)
        {
            await this.accountService.Login(request.Email, request.Password);
            return Ok();
        }
        
        [HttpGet("logout")]
        public async Task<ActionResult> LogoutAsync()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                var claimsIdentity = new ClaimsIdentity("Undefined");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
            }

            return Ok();
        }

        /*
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
        }*/
    }
}
