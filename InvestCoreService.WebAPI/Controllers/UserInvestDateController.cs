using Microsoft.AspNetCore.Mvc;
using InvestCoreService.API.Contracts.Requests.GetPotentialBonds;
using InvestCoreService.Domain.Models.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using InvestCoreService.Domain.Models.Enums;

namespace InvestCoreService.API.Controllers
{
    [ApiController]
    [Authorize(Policy = nameof(AccessLevel.User))]
    [Route("api/[controller]")]
    public class UserInvestDateController : ControllerBase
    {
        private readonly ILogger<UserInvestDateController> logger;
        private readonly ISecurityExchangeService service;

        public UserInvestDateController(ILogger<UserInvestDateController> logger, ISecurityExchangeService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet("portfolio/securityexchange/get/all")]
        public async Task<ActionResult<GetPotentialBondsResponse>> GetPotentialBondsAsync(int count) 
        {
            logger.LogInformation("SecurityExchangeController.GetPotentialBondsAsync - Time: {dateTime}; Count: {count}", DateTime.Now.ToShortTimeString(), count);
            var response = await service.GetPotentialBondsAsync(count);

            return Ok(response);
        }
    }
}
