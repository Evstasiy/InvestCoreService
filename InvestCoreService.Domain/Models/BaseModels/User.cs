using InvestCoreService.Domain.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace InvestCoreService.Domain.Models.BaseModels
{
    public class User //: IUserBase
    {
        [Key]
        public int UserId { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string PasswordHash { get; set; }
    }
}
