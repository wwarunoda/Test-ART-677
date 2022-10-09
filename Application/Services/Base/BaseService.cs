using Application.Contracts.Common;
using Application.Services.Abstractions.Base;
using AutoMapper;
using Domain.Entities.Base;
using Domain.Enums;
using Domain.Repositories.Abstractions.Base;

namespace Application.Services.Base
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public readonly IBaseRepository<T> _repository;
        public readonly IMapper _mapper;
        public BaseService(IBaseRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<ResponseVM<U>> GetByStateAsync<U>(string state, CommuneType communeType)
        {
            List<int> states = state.Split(',').ToList().Select(int.Parse).ToList();
            var entity = await _repository.GetByStateAsync(states, communeType);
            var newVM = new ResponseVM<U>() { Data = _mapper.Map<U>(entity) };
            return newVM;
        }

    }
}
