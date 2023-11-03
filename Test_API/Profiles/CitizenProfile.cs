using AutoMapper;
using Test_API.Request;
using Test_API.Response;
using Test_BusinessLogic;

namespace Test_API.Profiles
{
    public class CitizenProfile : Profile
    {
        public CitizenProfile() 
        {
            CreateMap<Citizen, CitizenResponse>();
            CreateMap<CitizenRequest, Citizen>();
        }
    }
}
