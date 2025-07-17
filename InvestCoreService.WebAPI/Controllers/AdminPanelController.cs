using InvestCoreService.Application.Interfaces.Services;
using InvestCoreService.Domain.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestCoreService.API.Controllers
{
    [ApiController]
    [Authorize(Policy = nameof(AccessLevel.Admin))]
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
