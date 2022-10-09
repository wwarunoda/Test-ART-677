

using Application.Contracts.Common;
using Application.Services.Abstractions;
using Application.Services.Base;
using AutoMapper;
using Domain;
using Domain.Repositories.Abstractions;

namespace Application.Services
{
    public class ResidenceService : BaseService<Actual>, IResidenceService
    {
        IResidenceRepository _residenceRepository;

        public ResidenceService(IResidenceRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _residenceRepository = repository;
        }
    }
}
