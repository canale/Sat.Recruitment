using AutoMapper;
using Sat.Recruitment.Domain.Dtos;

namespace Sat.Recruitment.Api.Helpers
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            this.CreateMap<UserCreationRequest, UserCreationDto>();
        }
    }
}
