using InvestCoreService.Domain.Models.Interfaces;

namespace InvestCoreService.Domain.Models.BaseModels
{
    public class User : IUserBase
    {
        private User(int userId, string? name, string? email, string? password)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
        }

        public int UserId { get; private set; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }

        public static User Create(int userId, string? name, string? email, string? password)
        {
            return new User(userId, name, email, password);
        }
    }
}
