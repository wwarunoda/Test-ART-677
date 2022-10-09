using Application.Contracts.Application.Residence;
using Application.Contracts.Common;
using Application.Services.Abstractions;
using Domain;
using Domain.Enums;
using Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResidenceController : BaseController<Actual>
    {
        public ResidenceController(IResidenceService residenceService) : base(residenceService)
        {
        }
        /// <summary>
        /// Get Population by state
        /// </summary>
        /// <param name="state">States</param>
        /// <returns>Population against the state</returns>
        [HttpGet("Population")]
        [SwaggerResponse(200, "Success", typeof(ResponseVM<IEnumerable<PopulationVM>>))]
        public async Task<IActionResult> GetPopulationAsync(string state)
        {
            return await GetByStateAsync<IEnumerable<PopulationVM>>(state, CommuneType.Population);
        }

        /// <summary>
        /// Get Household by state
        /// </summary>
        /// <param name="state">States</param>
        /// <returns>Household against the state</returns>
        [HttpGet("Household")]
        [SwaggerResponse(200, "Success", typeof(ResponseVM<IEnumerable<HouseholdVM>>))]
        public async Task<IActionResult> GetHouseholdAsync(string state)
        {
            return await GetByStateAsync<IEnumerable<HouseholdVM>>(state, CommuneType.Household);
        }
    }
}
