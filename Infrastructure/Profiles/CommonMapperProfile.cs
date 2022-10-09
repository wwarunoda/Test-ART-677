using Application.Contracts.Application.Residence;
using AutoMapper;
using Domain;

namespace Infrastructure.Profiles
{
    public class CommonMapperProfile : Profile
    {
        public CommonMapperProfile()
        {
            #region Vehicle Type Mappings
            #region Entity to VM
            CreateMap<Actual, PopulationVM>();
            CreateMap<Actual, HouseholdVM>();
            #endregion
            #endregion        

        }
    }
}
