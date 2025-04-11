using InvestCoreService.Application.Interfaces.Services;
using InvestCoreService.Application.Interfaces.Database;
using InvestCoreService.Application.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using InvestCoreService.Application.Interfaces.Auth;
using AutoMapper;
using InvestCoreService.Domain.Models.BaseModels;

namespace InvestCoreService.API.Services
{
    public class UserAccountService : IUserAccountService
    {
        private IDbContext dbContext {  get; set; }
        private IPasswordHasher passwordHasher {  get; set; }
        private IKeyGenerateService keyGenerateService {  get; set; }
        //private IMapper mapper {  get; set; }

        public UserAccountService(IDbContext dbContext, IPasswordHasher passwordHasher, IKeyGenerateService keyGenerateService)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
            this.keyGenerateService = keyGenerateService;
            //this.mapper = mapper;
        }

        public async Task Register(string userName, string email, string password)
        {
            var passwordHash = passwordHasher.Generate(password);
            var newUser = new User() 
            { 
                Name = userName,
                Email = email,
                PasswordHash = passwordHash
            };
           
            await dbContext.Users.AddAsync(newUser);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
            var resultPasswordCheck = passwordHasher.Verify(password, user!.PasswordHash!);
            if (user == null || !resultPasswordCheck)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            return keyGenerateService.GenerateToken(user);
        }

            /*
            public async Task UploadAllUserBondsInBrokersAsync(int userId)
            {
                var l = await dbContext.Users.ToListAsync();

                var brokers = GetAllConnectUserBrokers();
                List<Bond> userBonds = new List<Bond>();
                foreach (var broker in brokers)
                {
                    var bondsInBroker = await broker.GetBondManager().GetAllSecurityExchangeBondsAsync();
                    userBonds.AddRange(bondsInBroker);
                }
            }

            private List<IBaseBroker> GetAllConnectUserBrokers()
            {
                return new List<IBaseBroker>();
            }*/
    }
}
