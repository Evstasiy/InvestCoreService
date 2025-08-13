using Microsoft.AspNetCore.Mvc;
using InvestCoreService.API.Contracts.Requests.GetPotentialBonds;
using InvestCoreService.Domain.Models.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using InvestCoreService.Domain.Models.Enums;
using System.Security.Claims;
using InvestCoreService.Domain.Models.SecurityExchangeModels;

namespace InvestCoreService.API.Controllers
{
    [ApiController]
    [Authorize(Policy = nameof(AccessLevel.User))]
    [Route("api/user")]
    public class UserInvestDateController : ControllerBase
    {
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
        protected int UserId => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

        private readonly ILogger<UserInvestDateController> logger;
        private readonly ISecurityExchangeService service;

        public UserInvestDateController(ILogger<UserInvestDateController> logger, ISecurityExchangeService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet("portfolio/bond/get/all")]
        public async Task<ActionResult<List<Bond>>> GetUserBondsAsync() 
        {
            //logger.LogInformation("SecurityExchangeController.GetUserBondsAsync - Time: {dateTime}; Count: {count}", DateTime.Now.ToShortTimeString(), count);
            //Вынести лог в экстеншн logger.LogMethodEntry(...)
            var response = await service.GetUserBondsAsync(UserId);

            return Ok(response);
        }
        
        /*[HttpGet("portfolio/securityexchange/get/all")]
        public async Task<ActionResult<GetRecomendationBondsResponse>> GetRecomendationBondsAsync(int count) 
        {
            logger.LogInformation("SecurityExchangeController.GetRecomendationBondsAsync - Time: {dateTime}; Count: {count}", DateTime.Now.ToShortTimeString(), count);
            var response = await service.GetRecomendationBondsAsync(UserId, count);

            return Ok(response);
        }*/
    }
}
