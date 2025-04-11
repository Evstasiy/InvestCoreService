using AutoMapper;
using InvestCoreService.Application.Models.DTOs;
using InvestCoreService.Domain.Models.BaseModels;

namespace InvestCoreService.Application.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }

}
