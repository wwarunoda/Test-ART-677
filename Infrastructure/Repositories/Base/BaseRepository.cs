using AutoMapper;
using Domain;
using Domain.Entities;
using Domain.Entities.Base;
using Domain.Enums;
using Domain.Repositories.Abstractions.Base;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Configurations;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseResidenceEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public BaseRepository(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;

            //Read sample data and insert to the db
            ReadFileandLoadData();
        }

        /// <summary>
        /// Get households and population from database
        /// </summary>
        /// <param name="arrStates">states list</param>
        /// <param name="communeType">Household or Estimate</param>
        /// <returns>Households or population against to the state</returns>
        public virtual async Task<IEnumerable<T>> GetByStateAsync(List<int> arrStates, CommuneType communeType)
        {
            //filter actuals and estimates from states
            var actualsStateIds = GetActualIdbyState(arrStates);
            var estimateStates = arrStates.Except(actualsStateIds.Select(x => x.State).ToList());

            //select data against commune type
            if (communeType == CommuneType.Household)
            {
                var actuals = _mapper.Map<IEnumerable<T>>(_context.Actuals
                                .Where(b => actualsStateIds.Select(y => y.Id).Contains(b.Id)).Select(y => new HouseholdState
                                {
                                    State = y.State,
                                    Household = y.Household
                                }).ToList());

                var estimates = _context.Estimates
                            .Where(b => estimateStates.Contains(b.State))
                            .Select(y => new HouseholdState
                            {
                                State = y.State,
                                Household = y.Household
                            }).ToList();
                //Group data by state
                var estimateGroup = _mapper.Map<IEnumerable<T>>(
                                estimates.GroupBy(x => x.State)
                                .Select(y => new HouseholdState { 
                                    State = y.First().State, Household = y.Sum(c => c.Household) 
                                })
                            );
                //Contact actuals and estimates
                return actuals.Concat(estimateGroup);
            } else
            {
                var actuals = _mapper.Map<IEnumerable<T>>(_context.Actuals
                                .Where(b => actualsStateIds.Select(y => y.Id).Contains(b.Id)).Select(y => new PopulationState
                                {
                                    State = y.State,
                                    Population = y.Population
                                }).ToList());

                var estimates = _context.Estimates
                            .Where(b => estimateStates.Contains(b.State))
                            .Select(y => new PopulationState
                            {
                                State = y.State,
                                Population = y.Population
                            }).ToList();
                //Group data by state
                var estimateGroup = _mapper.Map<IEnumerable<T>>(
                        estimates.GroupBy(x => x.State)
                        .Select(y => new PopulationState { 
                            State = y.First().State, Population = y.Sum(c => c.Population) 
                        })
                    );
                //Concat actuals and estimates
                return actuals.Concat(estimateGroup);
            }
        }

        /// <summary>
        /// Filter states
        /// </summary>
        /// <param name="arrStates"></param>
        /// <returns></returns>
        private IEnumerable<CommonState> GetActualIdbyState(List<int> arrStates)
        {
            return _context.Actuals
                                .Where(b => arrStates.Contains(b.State))
                                .Select(y => new CommonState{ Id = y.Id, State = y.State}).ToList();
        }

        /// <summary>
        /// Read data file and insert
        /// </summary>
        private void ReadFileandLoadData()
        {
            //Insert data here for testing purposes
            var fileName = _configuration["DBFile:FileName"];
            var sheetActuals = _configuration["DBFile:Sheets:Actuals"];
            var sheetEstimates = _configuration["DBFile:Sheets:Estimates"];

            //Read file and get data
            var actuals = new FileConfiguration<Actual>().GetFileData(fileName, sheetActuals);
            var estimates = new FileConfiguration<Estimate>().GetFileData(fileName, sheetEstimates);

            //Delete data if already exists
            _context.Actuals.RemoveRange(_context.Actuals);
            _context.Estimates.RemoveRange(_context.Estimates);
            //Add data to DB
            _context.AddRange(actuals);
            _context.AddRange(estimates);
            _context.SaveChanges();
        }
    }
}
