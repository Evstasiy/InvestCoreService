namespace InvestCoreService.Application.Interfaces.Services
{
    public interface IUserAccountService
    {
        public Task Register(string userName, string email, string password);
        public Task<string> Login(string email, string password);
    }
}
