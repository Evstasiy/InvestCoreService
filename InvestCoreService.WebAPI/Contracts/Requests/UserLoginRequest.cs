using System.ComponentModel.DataAnnotations;

namespace InvestCoreService.API.Contracts.Requests
{
    public record UserLoginRequest(
        [Required] string Email,
        [Required] string Password
        );
}
