using InvestCoreService.API.Contracts.Requests;
using InvestCoreService.Application.Interfaces.Services;
using InvestCoreService.Domain.Models.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InvestCoreService.API.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminPanelController : ControllerBase
    {
        private ILogger<AdminPanelController> logger;
        private IUserAccountService accountService;
        public AdminPanelController(ILogger<AdminPanelController> logger, IUserAccountService accountService)
        {
            this.logger = logger;
            this.accountService = accountService;
        }

        [HttpGet("users/all")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await this.accountService.GetList(x => true);
            return Ok(users);
        }
    }
}
