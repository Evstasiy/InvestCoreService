namespace InvestCoreService.Application.Models.DTOs
{
    public class UserDTO
    {
        private UserDTO(int userId, string? name, string? email, string? passwordHash)
        {
            UserId = userId;
            Name = name;
            Email = email;
            PasswordHash = PasswordHash;
        }

        public int UserId { get; init; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? PasswordHash { get; private set; }

        public static UserDTO Create(int userId, string? name, string? email, string? passwordHash)
        {
            return new UserDTO(userId, name, email, passwordHash);
        }
    }
}
