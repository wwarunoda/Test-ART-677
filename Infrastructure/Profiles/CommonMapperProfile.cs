using Application.Contracts.Application.Residence;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Infrastructure.Profiles
{
    public class CommonMapperProfile : Profile
    {
        public CommonMapperProfile()
        {
            #region Vehicle Type Mappings
            #region Entity to VM
            CreateMap<Actual, Application.Contracts.Application.Residence.PopulationVM>();
            CreateMap<Actual, Application.Contracts.Application.Residence.HouseholdVM>();
            CreateMap<Domain.Entities.PopulationState, Actual>();
            CreateMap<Domain.Entities.HouseholdState, Actual>();
            #endregion
            #endregion        

        }
    }
}
