using Microsoft.AspNetCore.Authorization;

namespace InvestCoreService.API.Handlers
{
    public class AccessLevelHandler : AuthorizationHandler<AccessLevelRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AccessLevelRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
                return Task.CompletedTask;

            var claim = context.User.FindFirst("access_level");

            if (claim == null || !int.TryParse(claim.Value, out int userLevel))
                return Task.CompletedTask;

            if (userLevel >= requirement.RequiredLevel)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
