using Application.Contracts.Application.Base;
using Application.Contracts.Application.Residence;
using Domain;
using Domain.Entities.Base;
using Domain.EntityFilters.Base;
using Domain.Enums;
using Domain.Repositories.Abstractions.Base;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            //Insert data here for testing purposes
            //Read file and get data
            var actuals = new FileConfiguration<Actual>().GetFileData("Test.xlsx", "Actuals");
            var estimates = new FileConfiguration<Estimate>().GetFileData("Test.xlsx", "Estimates");
            //Delete data if already exists
            _context.Actuals.RemoveRange(_context.Actuals);
            _context.Estimates.RemoveRange(_context.Estimates);
            //Add data to DB
            _context.AddRange(actuals);
            _context.AddRange(estimates);
            _context.SaveChanges();
        }

        public virtual async Task<IEnumerable<Actual>> GetByStateAsync(List<int> arrStates, CommuneType communeType)
        {
            var actualsStateIds = _context.Actuals
                                .Where(b => arrStates.Contains(b.State)).Select(y => new
                                {
                                    Id = y.Id,
                                    State = y.State
                                }).ToList();
            var estimateStates = arrStates.Except(actualsStateIds.Select(x => x.State).ToList());
            if (communeType == CommuneType.Household)
            {
                var actuals = _context.Actuals
                                .Where(b => actualsStateIds.Select(y => y.Id).Contains(b.Id)).Select(y => new Actual
                                {
                                    State = y.State,
                                    Household = y.Household
                                }).ToList();

                var estimates = _context.Estimates
                            .Where(b => estimateStates.Contains(b.State))
                            .Select(y => new Actual
                            {
                                State = y.State,
                                Household = y.Household
                            }).ToList();
                var estimateGroup = estimates.GroupBy(x => x.State).Select(y => new Actual{ State = y.First().State, Household = y.Sum(c => c.Household) }).ToList();
                return actuals.Concat(estimateGroup);
            } else
            {
                var actuals = _context.Actuals
                                .Where(b => actualsStateIds.Select(y => y.Id).Contains(b.Id)).Select(y => new Actual
                                {
                                    State = y.State,
                                    Population = y.Population
                                }).ToList();

                    var estimates = _context.Estimates
                                .Where(b => estimateStates.Contains(b.State))
                                .Select(y => new Actual
                                {
                                    State = y.State,
                                    Population = y.Population
                                }).ToList();
                    var estimateGroup = estimates.GroupBy(x => x.State).Select(y => new Actual{ State= y.First().State, Population = y.Sum(c => c.Population) });
                    return actuals.Concat(estimateGroup);
            }
            
        }        
    }
}
