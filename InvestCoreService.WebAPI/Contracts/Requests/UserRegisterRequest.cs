using System.ComponentModel.DataAnnotations;

namespace InvestCoreService.API.Contracts.Requests
{
    public record UserRegisterRequest(
        [Required] string UserName,
        [Required] string Password,
        [Required] string Email
        );
}
