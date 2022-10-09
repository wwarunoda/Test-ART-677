using Application.Contracts.Common;
using Domain.Entities.Base;
using Domain.Enums;

namespace Application.Services.Abstractions.Base
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<ResponseVM<U>> GetByStateAsync<U>(string state, CommuneType communeType);

    }
}
