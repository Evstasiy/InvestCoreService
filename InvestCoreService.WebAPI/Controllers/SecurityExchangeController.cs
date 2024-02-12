using InvestCoreService.Domain.Requests.GetPotentialBonds;
using InvestCoreService.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestCoreService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityExchangeController : ControllerBase
    {
        private readonly ILogger<SecurityExchangeController> logger;
        private readonly ISecurityExchangeService service;

        public SecurityExchangeController(ILogger<SecurityExchangeController> logger, ISecurityExchangeService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet("bond/potential/get/{count}")]
        public async Task<ActionResult<GetPotentialBondsResponse>> GetPotentialBondsAsync(int count) 
        {
            logger.LogInformation("SecurityExchangeController.GetPotentialBondsAsync - Time: {dateTime}; Count: {count}", DateTime.Now.ToShortTimeString(), count);
            var response = await service.GetPotentialBondsAsync(count);

            return response;
        }
    }
}
