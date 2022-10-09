using AutoMapper;
using Domain;
using Domain.Repositories.Abstractions;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class ResidenceRepository: BaseRepository<Actual>, IResidenceRepository
    {
        public ResidenceRepository(ApplicationDbContext context, IConfiguration configuration, IMapper mapper) : base(context, configuration, mapper)
        {

        }
    }
}
