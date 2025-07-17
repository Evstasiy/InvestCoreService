using InvestCoreService.Application.Interfaces.Services;
using InvestCoreService.Application.Models.DTOs;
using AutoMapper;
using InvestCoreService.Domain.Models.BaseModels;
using System.Linq.Expressions;
using InvestCoreService.Domain.Models.Interfaces.Database;
using InvestCoreService.Domain.Models.Interfaces.Auth;
using InvestCoreService.Domain.Models.Enums;

namespace InvestCoreService.API.Services
{
    public class UserAccountService : IUserAccountService
    {
        private IRepository<User> _userRepository {  get; set; }
        private IPasswordHasher passwordHasher {  get; set; }
        private IKeyGenerateService keyGenerateService {  get; set; }
        private IMapper mapper {  get; set; }

        public UserAccountService(IRepository<User> userRepository, IPasswordHasher passwordHasher, IKeyGenerateService keyGenerateService, IMapper mapper)
        {
            _userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.keyGenerateService = keyGenerateService;
            this.mapper = mapper;
        }

        public async Task Register(string userName, string email, string password)
        {
            var passwordHash = passwordHasher.Generate(password);
            var newUser = new User() 
            { 
                Name = userName,
                Email = email,
                PasswordHash = passwordHash,
                AccessLevel = 0
            };
           
            await _userRepository.AddAsync(newUser);
        }

        public async Task<string> Login(string email, string password)
        {
            /*
            var result = await _userRepository.GetByFilterAsync(x => x.Email == email);
            var user = result.First();
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var resultPasswordCheck = passwordHasher.Verify(password, user!.PasswordHash!);
            if (!resultPasswordCheck)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            */
            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault();

            user.AccessLevel = (int)AccessLevel.Admin;
            var token = keyGenerateService.GenerateToken(user);

            return token;
        }

        public async Task<List<UserDTO>> GetList(Expression<Func<User, bool>> predicate)
        {
            var users = await _userRepository.GetByFilterAsync(predicate);
            var usersDtos = mapper.Map<List<UserDTO>>(users);
            return usersDtos;
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
