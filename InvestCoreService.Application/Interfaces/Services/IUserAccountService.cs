namespace InvestCoreService.Application.Interfaces.Services
{
    public interface IUserAccountService
    {
        public Task UploadAllUserBondsInBrokersAsync(int userId);
    }
}
