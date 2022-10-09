using Domain;
using Domain.Repositories.Abstractions;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ResidenceRepository: BaseRepository<Actual>, IResidenceRepository
    {
        public ResidenceRepository(ApplicationDbContext context) : base(context)
        {

        }
        //public override async Task<Actual> GetByStateAsync(string state, bool withIncludes = true, params string[] includeProperties)
        //{
        //    Actual actual = await base.GetByStateAsync(state, withIncludes, new string[] { "Creator", "Updater", "Deleter", "FromLocations.Location", "ToLocations.Location", "VehicleTypes.VehicleType", "Contacts", "Notes", "LastNote", "LastCall", "LastCall.LastNote", "Uploads" });

        //    return actual;
        //}
    }
}
