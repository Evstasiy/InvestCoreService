namespace InvestCoreService.API.Services.Interfaces
{
    public interface IUserAccountService
    {
        public Task UploadAllUserBondsInBrokersAsync(int userId);
    }
}
