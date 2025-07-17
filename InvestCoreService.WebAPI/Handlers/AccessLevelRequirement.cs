using Microsoft.AspNetCore.Authorization;

namespace InvestCoreService.API.Handlers
{
    public class AccessLevelRequirement : IAuthorizationRequirement
    {
        public int RequiredLevel { get; }

        public AccessLevelRequirement(int requiredLevel)
        {
            RequiredLevel = requiredLevel;
        }
    }
}
