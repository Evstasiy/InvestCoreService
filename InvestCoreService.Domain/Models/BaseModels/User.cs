using InvestCoreService.Domain.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestCoreService.Domain.Models.BaseModels
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string PasswordHash { get; set; }
        public required int AccessLevel { get; set; }
    }
}
